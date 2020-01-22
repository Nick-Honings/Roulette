using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using Roulette.Bets;
using System;
using System.Collections.Generic;

namespace Roulette.Users
{
    public class User : BaseUser, IPlayer, IUser, IUserDTO
    {
        // Dependencies
        private readonly IUserDAL _userDAL;
        private readonly IBetDAL _betDal;

        // Do not store password in this class because of security reasons.
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal Balance { get; set; } = 0;
        public int RoomId { get; set; }
        public IBet CurrentBet { get; private set; }


        public User(string name, IUserDAL userdal, IBetDAL betdal)
        {
            this.Name = name;
            this._userDAL = userdal;
            this._betDal = betdal;
            this.UserRole = 2;
            this.Permissions = new List<string>();
            if (betdal != null)
            {
                this.CurrentBet = MakeBetObject(betdal.GetCurrentBet(this.Id)); 
            }
        }

        // For testing purposes
        public User(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public bool UpdateProfile()
        {
            if (_userDAL.UpdateProfile(this))
            {
                return true;
            }
            return false;
        }

        public bool UpdateBalance(decimal balance)
        {           
            if(_userDAL.UpdateBalance(this.Id, balance))
            {
                return true;
            }
            return false;            
        }

        public bool MakeBet(IBet bet)
        {
            if (bet != null && Id != 0)
            {
                bet.Id = this.Id;
                CurrentBet = bet;

                if (_betDal.Save(MakeBetDTO(bet)))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Constructs a dto object of the specified bet
        /// Checks which bet type it is and maps this to dto object.
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        private IBetDTO MakeBetDTO(IBet bet)
        {
            var info = bet.GetBetSpecificInfo();
            IBetDTO output = null;

            if(bet.Type == BetType.Color)
            {
                if (info.TryGetValue("Color", out object temp))
                {
                    int color = (int)temp;
                    output = new ColorBet((IPocketColor)color)
                    {
                        Id = bet.Id,
                        Stake = bet.Stake,
                        
                    };
                }
            }
            else if (bet.Type == BetType.EvenUneven)
            {
                if (info.TryGetValue("IsEven", out object temp))
                {
                    bool isEven = (bool)temp;
                    output = new EvenUnevenBet(isEven)
                    {
                        Id = bet.Id,
                        Stake = bet.Stake,
                    };
                }
            }
            else if (bet.Type == BetType.Neighbour)
            {
                if (info.TryGetValue("FirstNumber", out object temp) && info.TryGetValue("SecondNumber", out object temp2))
                {
                    int firstNumber = (int)temp;
                    int secondNumber = (int)temp2;
                    output = new NeighbourBet((IPocketNumber)firstNumber, (IPocketNumber)secondNumber)
                    {
                        Id = bet.Id,
                        Stake = bet.Stake,
                    };
                }

            }
            else if (bet.Type == BetType.Single)
            {
                if (info.TryGetValue("Number", out object temp))
                {
                    int number = (int)temp;
                    output = new SingleNumberBet((IPocketNumber)number)
                    {
                        Id = bet.Id,
                        Stake = bet.Stake,
                    };
                }
            }
            return output;
        }


        private IBet MakeBetObject(IBetDTO dto)
        {
            if (dto == null)
                return null;


            var info = dto.GetBetSpecificInfo();
            IBet output = null;

            if (info.TryGetValue("Color", out object temp))
            {
                if (temp != null)
                {
                    int color = (int)temp;
                    output = new ColorBet((IPocketColor)color)
                    {
                        Id = dto.Id,
                        Stake = dto.Stake,
                    }; 
                }
            }
            else if (info.TryGetValue("FirstNumber", out object temp3) && info.TryGetValue("SecondNumber", out object temp4))
            {
                if (temp3 != null && temp4 != null)
                {
                    int firstNumber = (int)temp3;
                    int secondNumber = (int)temp4;
                    output = new NeighbourBet((IPocketNumber)firstNumber, (IPocketNumber)secondNumber)
                    {
                        Id = dto.Id,
                        Stake = dto.Stake,
                    }; 
                }
            }
            else if (info.TryGetValue("Number", out object temp5))
            {
                if (temp5 != null)
                {
                    int number = (int)temp;
                    output = new SingleNumberBet((IPocketNumber)number)
                    {
                        Id = dto.Id,
                        Stake = dto.Stake,
                    }; 
                }
            }
            else if (info.TryGetValue("IsEven", out object temp2))
            {
                if (temp2 != null)
                {
                    bool isEven = (bool)temp;
                    output = new EvenUnevenBet(isEven)
                    {
                        Id = dto.Id,
                        Stake = dto.Stake,
                    };
                }
            }

            return output;
        }



        public void StartBattle(int playerId)
        {
            throw new NotImplementedException();
        }
    }
}