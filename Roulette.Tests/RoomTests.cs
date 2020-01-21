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


            player = new User("test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 1
            };
            round = new Round(8, repo.CreateRoundDAL(), wheel);
        }


        [Fact]
        public void AddRound_ShouldWork()
        {
            // Arrange               
            int expected = TestDB.GetRoundsTable().Count(i => i.RoomId == 1) + 1;
            
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
            int expected = 1;
            room.AddUser(player);

            // Act
            room.RemoveUser(player);
            int result = room.Players.Count;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
