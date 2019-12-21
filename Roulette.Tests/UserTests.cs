﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.Users;
using Roulette.Bets;
using DataAccesFactory;
using Roulette.GameStructure;

namespace Roulette.Tests
{
    public class UserTests
    {
        User user;
        IBet bet;
        

        public UserTests()
        {
            user = new User("test", TestFactory.CreateTestUserDAL());
            bet = new ColorBet(PocketColor.Black, null);
        }

        [Fact]
        public void MakeBet_ShouldWork()
        {
            // Arrange
            decimal expected = 10;

            // Act
            user.MakeBet(bet, 10);
            decimal result = user.CurrentBet.Stake;
            

            // Assert
            Assert.Equal(expected, result);
            Assert.IsAssignableFrom<ColorBet>(user.CurrentBet);
        }
    }
}
