using DataAccesFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roulette.Tests
{
    public class RoomContainerTests
    {
        RoomContainer container;
        Room room;
        Room emptyRoom;

        public RoomContainerTests()
        {
            container = new RoomContainer(TestFactory.CreateTestRoomContainerDAL());
            room = new Room("Speed Roulette", TestFactory.CreateTestRoomDAL());
        }

        [Fact]
        public void AddRoom_ShouldWork()
        {
            // Arrange
            int expected = 1;

            // Act
            container.AddRoom(room);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(room, container.Rooms[0]);
        }

        [Fact]
        public void AddRoom_ShouldNotAddEmptyClassToList()
        {
            // Arrange
            int expected = 0;

            // Act
            container.AddRoom(emptyRoom);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveRoom_ShouldWorkWithOneEntry()
        {
            // Arrange
            int expected = 0;
            container.AddRoom(room);

            // Act
            container.RemoveRoom(room);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveRoom_ShouldWorkWithMultipleEntries()
        {
            // Arrange
            int expected = 1;
            container.AddRoom(room);
            container.AddRoom(new Room("Live Roulette", TestFactory.CreateTestRoomDAL()));

            // Act
            container.RemoveRoom(room);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal("Live Roulette", container.Rooms[0].Name);
        }

        [Fact]
        public void RemoveRoom_ShouldDoNothingWithEmptyClass()
        {
            // Arrange
            int expected = 1;
            container.AddRoom(room);


            // Act
            container.RemoveRoom(emptyRoom);
            int result = container.Rooms.Count;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
