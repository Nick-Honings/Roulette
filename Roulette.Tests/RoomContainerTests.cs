using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataAccesFactory;
using TestDatabase.TestDatabase;
using Xunit;

namespace Roulette.Tests
{
    public class RoomContainerTests
    {
        RoomContainer container;
        Room room;
        Room emptyRoom;
        InMemRepository repo;

        public RoomContainerTests()
        {
            repo = new InMemRepository();
            container = new RoomContainer(
                repo.CreateRoomContainerDAL(), 
                repo.CreateRoomDAL(), 
                repo.CreateRoundDAL(),
                repo.CreateUserDAL(),
                repo.CreateBetDAL(),
                new Wheel(new NumberGenerator()));

            room = new Room(1, 
                repo.CreateRoomDAL(), 
                repo.CreateRoundDAL(), 
                repo.CreateUserDAL(),
                repo.CreateBetDAL(),
                new Wheel(new NumberGenerator()));
        }

        [Fact]
        public void AddRoom_ShouldWork()
        {
            // Arrange
            int expected = TestDataBase.GetRoomsTable().Count + 1;

            // Act
            bool validCall = container.AddRoom(room);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);
        }

        [Fact]
        public void AddRoom_ShouldNotAddEmptyClassToList()
        {
            // Arrange
            int expected = TestDataBase.GetRoomsTable().Count;

            // Act
            bool validCall = container.AddRoom(emptyRoom);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.False(validCall);
        }

        [Fact]
        public void RemoveRoom_ShouldWorkWithOne()
        {
            // Arrange
            var rooms = TestDataBase.GetRoomsTable();
            Room toRemove = (Room)rooms[0];
            int expected = rooms.Count - 1;

            // Act
            bool validCall = container.RemoveRoom(toRemove);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);
        }

        [Fact]
        public void RemoveRoom_ShouldWorkWithMultipleEntries()
        {
            // Arrange
            var rooms = TestDataBase.GetRoomsTable();
            Room toRemove = (Room)rooms[0];
            int expected = rooms.Count - 1;

            // Act
            bool validCall = container.RemoveRoom(toRemove);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);            
            Assert.True(validCall);
        }

        [Fact]
        public void RemoveRoom_ShouldDoNothingWithEmptyClass()
        {
            // Arrange
            int expected = TestDataBase.GetRoomsTable().Count + 1;
            container.AddRoom(room);


            // Act
            bool validCall = container.RemoveRoom(emptyRoom);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.False(validCall);
        }

        [Fact]
        public void GetAllRooms_ShouldWorkAfterInitialisation()
        {
            // Arrange
            var roomsExpected = TestDataBase.GetRoomsTable();
            int expected = roomsExpected.Count;

            // Act
            var roomsResult = container.Rooms;
            int result = roomsResult.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        //INTEGRATION TEST//
        // Tests if all classes are properly initialized with the data from a database.
        [Fact]
        public void GetAllINTEGRATION_ShouldGetCalledAfterInitialisation()
        {
            // Arrange 
            var roomsExpected = TestDataBase.GetRoomsTable();
            var roundsExpected = TestDataBase.GetRoundsTable();
            var pocketsExpected = TestDataBase.GetPocketTable();
            var usersExpected = TestDataBase.GetUserTable();

            int roomsCountExpected = roomsExpected.Count;
            int roundsCountExpected = roundsExpected.Count;
            int playerCountExpected = usersExpected.Count;
            int pocketsCountExpected = pocketsExpected.Count;
            

            // Act
            // Initializing RoomContainer should inititialize all data of rooms, rounds and pockets.
            RoomContainer container = new RoomContainer(repo.CreateRoomContainerDAL(),
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
                var tempRoom = room;
                foreach (var round in tempRoom.Rounds)
                {
                    roundsCountResult++;
                    var tempRound = round;
                    
                    if(tempRound.Pocket != null)
                    {
                        pocketsCountResult++;
                    }
                }
                foreach (var player in tempRoom.Players)
                {
                    playerCountResult++;
                }
            }

            // Assert
            Assert.Equal(roomsCountExpected, roomsCountResult);
            Assert.Equal(roundsCountExpected, roundsCountResult);
            Assert.Equal(pocketsCountExpected, pocketsCountResult);
        }
    }
}
