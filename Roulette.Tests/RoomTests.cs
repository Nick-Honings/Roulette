﻿using System;
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
        User user;
        Round round;

        public RoomTests()
        {
            room = new Room("Speed roulette");
            user = new User("test");
            round = new Round(1);
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
        public void AddRound_ShouldNotWorkWithDuplicateID()
        {
            // Arrange
            int expected = 1;
            room.AddRound(round);

            // Act
            room.AddRound(new Round(1));
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
            room.AddUser(user);
            int result = room.Players.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(user, room.Players[0]);
        }

        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            int expected = 0;
            room.AddUser(user);

            // Act
            room.RemoveUser(user);
            int result = room.Players.Count;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [ClassData(typeof(RoomTestsData.PositiveBets))]
        public void UpdateUserBalance_ShouldUpdate(Result betResult, IBet bet, double expected)
        {
            // Arrange            
            room.AddUser(user);
            user.MakeBet(bet, 10);
            room.AddRound(round);
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
            room.AddUser(user);
            user.MakeBet(bet, 10);
            room.AddRound(round);
            room.Rounds[0].AddResult(betResult);

            // Act
            room.UpdateUserBalance();
            double result = user.Balance;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
