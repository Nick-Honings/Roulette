﻿using InterfaceLayerBD;
using InterfaceLayerBD.Bet;

using System;

namespace Roulette.Users
{
    public class User : BaseUser, IPlayer, IUser, IUserDTO
    {
        // Do not store password in this class because of security reasons.
        public int Id { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal Balance { get; set; } = 0;
        public IBet CurrentBet { get; private set; }

        private IUserDAL userDAL;
        

        public User(string name, IUserDAL dal)
        {
            Name = name;
            userDAL = dal;
        }

        public void UpdateProfile()
        {
            IUserDTO dTO = new User(Name, null)
            {
                Email = this.Email,
                Age = this.Age,
                IsActive = this.IsActive,
                Balance = this.Balance
            };
            userDAL.Update(dTO);
        }

        public void MakeBet(IBet bet, decimal stake)
        {
            if (bet != null)
            {
                bet.Stake = stake;
                bet.ID = this.Id;
                CurrentBet = bet;                
            }
        }
    }
}