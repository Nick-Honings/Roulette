using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

using Roulette.Tests.TestData;
using Roulette.Users;
using DataAccesFactory;
using Roulette.GameStructure;

namespace Roulette.Tests
{
    public class RoomTests
    {
        Room room;
        IPlayer player;
        Round round;
        IWheel wheel;
        IGenerator generator;

        public RoomTests()
        {
            generator = new NumberGenerator();
            wheel = new Wheel(generator);
            room = new Room("Speed roulette", TestFactory.CreateTestRoomDAL());
            player = new User("test", TestFactory.CreateTestUserDAL());
            round = new Round(wheel, 30);
        }


        [Fact]
        public void AddRound_ShouldWork()
        {
            // Arrange
            int expected = 1;

            round.Id = 1;
            round.TimeLeft = 30;

            // Act
            room.StartNewRound();
            int result = room.Rounds.Count;

            // Assert
            Assert.Equal(expected, result);            
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
        public void UpdateUserBalance_ShouldUpdate(IPocket betResult, IBet bet, decimal expected)
        {
            // Arrange            
            room.AddUser(player);
            player.MakeBet(bet, 10);
            room.StartNewRound();
            room.Rounds[0].Pocket = betResult;

            // Act
            room.UpdateUserBalance();
            decimal result = player.Balance;

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(RoomTestsData.NegativeBets))]
        public void UpdateUserBalance_ShouldDoNothing(IPocket betResult, IBet bet, decimal expected)
        {
            // Arrange
            room.AddUser(player);
            player.MakeBet(bet, 10);
            room.StartNewRound();
            room.Rounds[0].Pocket = betResult;

            // Act
            room.UpdateUserBalance();
            decimal result = player.Balance;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
