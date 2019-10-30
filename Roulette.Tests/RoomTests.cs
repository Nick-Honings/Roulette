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
        Room room;
        IPlayer player;
        Round round;

        public RoomTests()
        {
            room = new Room("Speed roulette");
            player = new User("test");
            round = new Round();
        }


        [Fact]
        public void AddRound_ShouldWork()
        {
            // Arrange
            int expected = 1;

            // Act
            room.AddRound(round);
            int result = room.Rounds.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(round, room.Rounds[0]);
        }

        [Fact]
        public void AddRound_ShouldIncrementID()
        {
            // Arrange
            int expected1 = 1;
            int expected2 = 2;
            int expected3 = 3;

            room.AddRound(round);
            room.AddRound(new Round());
            room.AddRound(new Round());

            // Act
            int result1 = room.Rounds[0].RoundId;
            int result2 = room.Rounds[1].RoundId;
            int result3 = room.Rounds[2].RoundId;

            // Assert
            Assert.Equal(expected1, result1);
            Assert.Equal(expected2, result2);
            Assert.Equal(expected3, result3);
        }

        [Fact]
        public void AddUser_ShouldWork()
        {
            // Arrange
            int expected = 1;

            // Act
            room.AddUser(player);
            int result = room.Players.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(player, room.Players[0]);
        }

        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            int expected = 0;
            room.AddUser(player);

            // Act
            room.RemoveUser(player);
            int result = room.Players.Count;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [ClassData(typeof(RoomTestsData.PositiveBets))]
        public void UpdateUserBalance_ShouldUpdate(Result betResult, IBet bet, double expected)
        {
            // Arrange            
            room.AddUser(player);
            player.MakeBet(bet, 10);
            room.AddRound(round);
            room.Rounds[0].AddResult(betResult);

            // Act
            room.UpdateUserBalance();
            double result = player.Balance;

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(RoomTestsData.NegativeBets))]
        public void UpdateUserBalance_ShouldDoNothing(Result betResult, IBet bet, double expected)
        {
            // Arrange
            room.AddUser(player);
            player.MakeBet(bet, 10);
            room.AddRound(round);
            room.Rounds[0].AddResult(betResult);

            // Act
            room.UpdateUserBalance();
            double result = player.Balance;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
