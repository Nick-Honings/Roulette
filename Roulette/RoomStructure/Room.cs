using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD.Room;
using Roulette.Bets;
using Roulette.GameStructure;
using Roulette.Users;

namespace Roulette
{
    public class Room : IRoomDTO
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int Capacity { get; set; } = 20;
        public double StakeUpLim { get; set; } = 2500;
        public double StakeLowLim { get; set; } = 0.5;
        public int RoundTime { get; set; } = 30;

        public List<Round> Rounds { get; private set; }
        public List<IPlayer> Players { get; private set; }

        private int numberOfRounds = 1;
        private IRoomDAL RoomDAL;

        public Room(string name, IRoomDAL dAL)
        {
            Name = name;
            Rounds = new List<Round>();
            Players = new List<IPlayer>();
            RoomDAL = dAL;
        }

        public void StartNewRound()
        {
            Round round = new Round(new Wheel(new NumberGenerator()), RoundTime)
            {
                RoundId = numberOfRounds,                
            };
            Rounds.Add(round);
            numberOfRounds++;
        }

        public void AddUser(IPlayer player)
        {
            if (player != null)
            {
                Players.Add(player);

            }        
        }

        public void RemoveUser(IPlayer player)
        {
            Players.Remove(player);
        }
        // Obsolete
        //public void UpdateUserBalance()
        //{
        //    Result result = Rounds[Rounds.Count - 1].GetResult();

        //    foreach ( IPlayer p in Players)
        //    {
        //        IBet bet = p.CurrentBet;
        //        if(bet is ColorBet cBet)
        //        {
        //            if(cBet.Color == result.Color)
        //            {
        //                p.Balance += cBet.GetReturnStake();
        //            }
        //        }
        //        if (bet is EvenUnevenBet eBet)
        //        {
        //            if (eBet.IsEven == result.IsEven)
        //            {
        //                p.Balance += eBet.GetReturnStake();
        //            }
        //        }
        //        if (bet is NeighbourBet nBet)
        //        {
        //            if (nBet.Neighbours[0] == result.Number | nBet.Neighbours[1] == result.Number)
        //            {
        //                p.Balance += nBet.GetReturnStake();
        //            }
        //        }
        //        if (bet is SingleNumberBet sBet)
        //        {
        //            if (sBet.Number == result.Number)
        //            {
        //                p.Balance += sBet.GetReturnStake();
        //            }
        //        }
        //    }
        //}

        // Using
        public void UpdateUserBalance()
        {
            IPocket pocket = Rounds[Rounds.Count - 1].Pocket;
            foreach (IPlayer p in Players)
            {
                IBet bet = p.CurrentBet;
                if (bet is ColorBet cBet)
                {
                    if (cBet.Color == pocket.Color)
                    {
                        p.Balance += cBet.GetReturnStake();
                    }
                }
                if (bet is EvenUnevenBet eBet)
                {
                    if (eBet.IsEven == pocket.Even)
                    {
                        p.Balance += eBet.GetReturnStake();
                    }
                }
                if (bet is NeighbourBet nBet)
                {
                    if (nBet.FirstNumber == pocket.Number | nBet.SecondNumber == pocket.Number)
                    {
                        p.Balance += nBet.GetReturnStake();
                    }
                }
                if (bet is SingleNumberBet sBet)
                {
                    if (sBet.PocketNumber == pocket.Number)
                    {
                        p.Balance += sBet.GetReturnStake();
                    }
                }
            }
        }
    }
}
