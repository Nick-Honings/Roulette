using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using Roulette.Bets;
using Roulette.GameStructure;
using Roulette.Users;

namespace Roulette
{
    public class Room : IRoomDTO
    {
        // Dependencies
        private readonly IRoomDAL _roomDAL;
        private readonly IRoundDAL _roundDAL;
        private readonly IBetDAL _betDAL;
        private readonly IUserDAL _userDAL;
        private readonly IWheel _wheel;


        public int Id { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double StakeUpLim { get; set; }
        public double StakeLowLim { get; set; } 
        public int RoundTime { get; set; }

        public List<Round> Rounds { get; private set; }
        public List<IPlayer> Players { get; private set; }

        public Room(int id, 
            IRoomDAL roomDAL, 
            IRoundDAL roundDAL, 
            IUserDAL userDAL, 
            IBetDAL _betDAL,
            IWheel wheel)
        {
            this.Id = id;

            this._roomDAL = roomDAL;
            this._roundDAL = roundDAL;
            this._betDAL = _betDAL;
            this._userDAL = userDAL;
            this._wheel = wheel;

            this.Rounds = this.GetAllRounds();
            this.Players = this.GetAllUsers();
        }

        //This is only used for testing so it can be added
        // To the in mem database without creating
        // a type error.
        public Room(int id)
        {
            this.Id = id;
        }

        public void StartNewRound()
        {
            Round newRound = new Round(this.Rounds.Count + 1, _roundDAL, _wheel)
            {
                RoomId = this.Id,
                RoundTime = RoundTime
            };
            
            if (_roomDAL.SaveRound(newRound))
            {
                Rounds.Add(newRound);
                newRound.Start();
            }           
            
            //Update statement needs to happen here.
            
        }


        public void AddUser(IPlayer player)
        {
            if (player != null)
            {                
                if(_roomDAL.AddUser(player.Id, this.Id))
                {
                    Players.Add(player);
                }
            }        
        }

        public void RemoveUser(IPlayer player)
        {
            // if player enters the room, its room id has to be set to this id.

            if (player != null)
            {
                if (_roomDAL.RemoveUser(player.Id, this.Id))
                {
                    Players.Remove(player);
                }
            }
        }
        
        internal List<Round> GetAllRounds()
        {
            List<Round> rounds = new List<Round>();
            var dtos = _roomDAL.GetAllRounds(this.Id);

            foreach (var d in dtos)
            {
                rounds.Add(ExtractRound(d));
            }
            return rounds;
        }

        private List<IPlayer> GetAllUsers()
        {
            List<IPlayer> rounds = new List<IPlayer>();
            var dtos = _roomDAL.GetAllUsers(this.Id);

            foreach (var d in dtos)
            {
                rounds.Add(ExtractPlayer(d));
            }
            return rounds;
        }

        private IPlayer ExtractPlayer(IUserDTO d)
        {
            IPlayer player = new User(d.Name, _userDAL, _betDAL)
            {
                Id = d.Id,
                Balance = d.Balance
            };
            return player; 
        }

        // Might need testing
        private void UpdateUserBalance()
        {
            IPocket pocket = Rounds[Rounds.Count - 1].Pocket;
            foreach (IPlayer p in Players)
            {
                IBet bet = p.CurrentBet;
                IfColorBetUpdateBalance(pocket, p, bet);
                IfEvenBetUpdateBalance(pocket, p, bet);
                ifNeighbourUpdateBalance(pocket, p, bet);
                IfSingleUpdateBalance(pocket, p, bet);
            }
        }

        private static void IfSingleUpdateBalance(IPocket pocket, IPlayer p, IBet bet)
        {
            if (bet is SingleNumberBet sBet)
            {
                if (sBet.Number == pocket.Number)
                {
                    p.UpdateBalance(sBet.GetReturnStake());
                }
            }
        }

        private static void ifNeighbourUpdateBalance(IPocket pocket, IPlayer p, IBet bet)
        {
            if (bet is NeighbourBet nBet)
            {
                if (nBet.FirstNumber == pocket.Number | nBet.SecondNumber == pocket.Number)
                {
                    p.UpdateBalance(nBet.GetReturnStake());
                }
            }
        }

        private static void IfEvenBetUpdateBalance(IPocket pocket, IPlayer p, IBet bet)
        {
            if (bet is EvenUnevenBet eBet)
            {
                if (eBet.IsEven == pocket.Even)
                {
                    p.UpdateBalance(eBet.GetReturnStake());
                }
            }
        }

        private static void IfColorBetUpdateBalance(IPocket pocket, IPlayer p, IBet bet)
        {
            if (bet is ColorBet cBet)
            {
                if (cBet.Color == pocket.Color)
                {
                    p.UpdateBalance(cBet.GetReturnStake());
                }
            }
        }

        private Round ExtractRound(IRoundDTO dto)
        {
            return new Round(dto.Id, _roundDAL, _wheel)
            {
                RoomId = dto.RoomId,
                HasEnded = dto.HasEnded
            };
        }
    
    
        // After the round has ended, it will raise an event.
        // This method is to subscribe to the the event and stop the round.
        private void ReceiveRoundEndedNotification(object sender, RoundEndedEventArgs e)
        {
            this.UpdateUserBalance();              
            
            this.StartNewRound();
        }  

        
    }
}
