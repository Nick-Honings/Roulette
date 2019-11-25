using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.Users;
using DataAccesFactory;

namespace Roulette.Tests
{
    public class UserContainerTests
    {
        UserContainer container;
        User user;
        User emptyUser;


        public UserContainerTests()
        {
            container = new UserContainer(TestFactory.CreateTestUserContainerDAL());
            user = new User("Test", TestFactory.CreateTestUserDAL());
        }

        [Fact]
        public void AddUser_ShouldWork()
        {
            // Arrange
            int expected = 1;

            // Act
            container.AddUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(user, container.Users[0]);
        }

        [Fact]
        public void AddUser_ShouldNotAddEmptyClass()
        {
            // Arrange
            int expected = 0;

            // Act
            container.AddUser(emptyUser);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            int expected = 0;
            container.AddUser(user);

            // Act
            container.RemoveUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveUser_ShouldNotAttemptRemoveEmptyClass()
        {
            // Arrange
            int expected = 1;
            container.AddUser(user);
            user = null;

            // Act
            container.RemoveUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
