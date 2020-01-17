using Roulette.Users;
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
    public class AdminTests
    {
        InMemRepository repo;
        Admin admin;
        User user;
        UserContainer container;

        public AdminTests()
        {
            repo = new InMemRepository();
            admin = new Admin(repo.CreateAdminDAL());
            user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL());
            container = new UserContainer(repo.CreateUserContainerDAL(), repo.CreateUserDAL(), repo.CreateBetDAL());
            
            admin.NewUserAdded += container.ReceiveNewUserNotification;
            admin.UserModification += container.ReceiveUserModificationNotification;
        }


        [Fact]
        public void AddUser_ShouldWork()
        {
            // Arrange
            int expected = container.Users.Count + 1;

            // Act
            bool validCall = admin.AddUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);
        }

        [Fact]
        public void AddUser_ShouldNotAddEmptyClass()
        {
            // Arrange
            User emptyUser = null;
            int expected = TestDB.GetUserTable().Count;

            // Act
            bool validCall = admin.AddUser(emptyUser);
            int result = container.Users.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);            
        }

        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            var users = TestDB.GetUserTable();
            User toRemove = (User)users[0];
            int expected = users.Count - 1;

            // Act
            bool validCall = admin.RemoveUser(toRemove.Id);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);
        }

        [Fact]
        public void RemoveUser_ShouldReturnFalse()
        {
            // Arrange            
            int expected = TestDB.GetUserTable().Count;

            // Act
            bool validCall = admin.RemoveUser(expected + 100);
            int result = container.Users.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EnableUser_ShouldWork()
        {
            // Arrange
            User toEnable = (User)TestDB.GetUserTable()[0];

            // Act
            bool validCall = admin.DisableUser(toEnable.Id);
            var result = container.Users.Find(i => i.Id == toEnable.Id);


            // Assert
            Assert.True(validCall);
            Assert.False(result.IsActive);
        }

        [Fact]
        public void EnableUser_ShouldReturnFalse()
        {
            // Arrange
            int userCount = TestDB.GetUserTable().Count;

            // Act
            bool validCall = admin.DisableUser(userCount + 100);

            // Assert
            Assert.False(validCall);
        }

        [Fact]
        public void DisableUser_ShouldWork()
        {
            // Arrange
            User toDisable = (User)TestDB.GetUserTable()[0];

            // Act
            bool validCall = admin.DisableUser(toDisable.Id);
            var result = container.Users.Find(i => i.Id == toDisable.Id);


            // Assert
            Assert.True(validCall);
            Assert.False(result.IsActive);
        }

        [Fact]
        public void DisableUser_ShouldReturnFalse()
        {
            // Arrange
            int userCount = TestDB.GetUserTable().Count;

            // Act
            bool validCall = admin.DisableUser(userCount + 100);

            // Assert
            Assert.False(validCall);
        }

        [Fact]
        public void SetUserBalance_ShouldSetBalance()
        {
            // Arrange
            decimal expected = 2500;
            User toEditBalance = (User)TestDB.GetUserTable()[0];

            // Act
            bool validCall = admin.SetUserBalance(toEditBalance.Id, expected);
            decimal result = container.Users.Find(i => i.Id == toEditBalance.Id).Balance;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);
        }

        [Fact]
        public void SetUserBalance_ShouldReturnFalse()
        {
            int userCount = TestDB.GetUserTable().Count;

            // Act
            bool validCall = admin.SetUserBalance(userCount + 100, 2500);

            // Assert
            Assert.False(validCall);
        }

    }
}
