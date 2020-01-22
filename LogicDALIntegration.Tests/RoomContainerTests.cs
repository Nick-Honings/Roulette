using Roulette;
using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TestDataAccesFactory;
using Xunit;

namespace LogicDALIntegration.Tests
{
    public class RoomContainerTests
    {
        RoomContainer container;
        MySqlRepository repo;
        

        public RoomContainerTests()
        {
            repo = new MySqlRepository("TestDatabase");

        }


        [Fact]
        public void GetAllRooms_ShouldWork()
        {
            // Arrange
            int roomsCountExpected = 2;
            int roundsCountExpected = 4;
            int playerCountExpected = 3;
            int pocketsCountExpected = 4;

            // Act
            using (TransactionScope scope = new TransactionScope())
            {
                container = new RoomContainer(
                                        repo.CreateRoomContainerDAL(),
                                        repo.CreateRoomDAL(),
                                        repo.CreateRoundDAL(),
                                        repo.CreateUserDAL(),
                                        repo.CreateBetDAL(),
                                        new Wheel(new NumberGenerator()));


                int roomsCountResult = 0;
                int roundsCountResult = 0;
                int playerCountResult = 0;
                int pocketsCountResult = 0;


                foreach (var room in container.Rooms)
                {
                    roomsCountResult++;

                    foreach (var round in room.Rounds)
                    {
                        roundsCountResult++;

                        if (round.Pocket != null)
                        {
                            pocketsCountResult++;
                        }
                    }
                    foreach (var player in room.Players)
                    {
                        playerCountResult++;
                    }
                }

                // Assert
                Assert.Equal(roomsCountExpected, roomsCountResult);
                Assert.Equal(roundsCountExpected, roundsCountResult);
                Assert.Equal(playerCountExpected, playerCountResult);
                Assert.Equal(pocketsCountExpected, pocketsCountResult);                
            }
        }        
    }
}
