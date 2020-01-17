using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

using Roulette.Tests.TestData;
using Roulette.Users;
using Roulette.GameStructure;
using TestDataAccesFactory;
using Roulette.Bets;
using TestDatabase.TestDatabase;

namespace Roulette.Tests
{
    public class RoomTests
    {
        Room room;
        IPlayer player;
        Round round;
        IWheel wheel;
        IGenerator generator;
        InMemRepository repo;

        public RoomTests()
        {
            repo = new InMemRepository();
            generator = new NumberGenerator();
            wheel = new Wheel(generator);
            room = new Room(1, repo.CreateRoomDAL(), repo.CreateRoundDAL(), repo.CreateUserDAL(), repo.CreateBetDAL(), wheel);


            player = new User("test", repo.CreateUserDAL(), repo.CreateBetDAL());
            round = new Round(8, repo.CreateRoundDAL(), wheel);
        }


        [Fact]
        public void AddRound_ShouldWork()
        {
            // Arrange
            
            int expected = TestDB.GetRoundsTable().Where(i=> i.Id == 1).Count() + 1;
            
            // Act
            room.StartNewRound();
            int result = room.Rounds.Count;

            // Assert
            Assert.Equal(expected, result);            
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

        //[Theory]
        //[ClassData(typeof(RoomTestsData.PositiveBets))]
        //public void UpdateUserBalance_ShouldUpdate(IPocket betResult, IBet bet, decimal expected)
        //{
        //    // Arrange            
        //    room.AddUser(player);
        //    bet.Stake = 10;
        //    player.MakeBet(bet);
        //    room.StartNewRound();
        //    room.Rounds[0].Pocket = betResult;

        //    // Act
        //    room.UpdateUserBalance();
        //    decimal result = player.Balance;

        //    // Assert
        //    Assert.Equal(expected, result);
        //}

        //[Theory]
        //[ClassData(typeof(RoomTestsData.NegativeBets))]
        //public void UpdateUserBalance_ShouldDoNothing(IPocket betResult, IBet bet, decimal expected)
        //{
        //    // Arrange
        //    room.AddUser(player);
        //    bet.Stake = 10;
        //    player.MakeBet(bet);
        //    room.StartNewRound();
        //    room.Rounds[0].Pocket = betResult;

        //    // Act
        //    room.UpdateUserBalance();
        //    decimal result = player.Balance;

        //    // Assert
        //    Assert.Equal(expected, result);
        //}
    }
}
