using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.Tests.TestData;
using Roulette.Users;

namespace Roulette.Tests
{
    public class RoomTests
    {
        [Theory]
        [ClassData(typeof(RoomTestsData.PositiveBets))]
        public void UpdateUserBalance_ShouldUpdate(Result betResult, IBet bet, double expected)
        {
            // Arrange            
            Room room = new Room("Speed roulette");
            User user = new User("Test");
            room.AddUser(user);
            user.MakeBet(bet, 10);
            room.AddRound(new Round(1));
            room.Rounds[0].AddResult(betResult);

            // Act
            room.UpdateUserBalance();
            double result = user.Balance;

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(RoomTestsData.NegativeBets))]
        public void UpdateUserBalance_ShouldDoNothing(Result betResult, IBet bet, double expected)
        {
            // Arrange
            Room room = new Room("Speed roulette");
            User user = new User("Test");
            room.AddUser(user);
            user.MakeBet(bet, 10);
            room.AddRound(new Round(1));
            room.Rounds[0].AddResult(betResult);

            // Act
            room.UpdateUserBalance();
            double result = user.Balance;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
