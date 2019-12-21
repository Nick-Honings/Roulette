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
            bool validCall = container.AddUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);
            Assert.Equal(user, container.Users[0]);
        }

        [Fact]
        public void AddUser_ShouldNotAddEmptyClass()
        {
            // Arrange
            int expected = 0;

            // Act
            bool validCall = container.AddUser(emptyUser);
            int result = container.Users.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            int expected = 0;
            container.AddUser(user);

            // Act
            bool validCall = container.RemoveUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.True(validCall);
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
            bool validCall = container.RemoveUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAllUsers_ShouldWork()
        {
            //// Arrange            
            //var expected = TestDB.ReturnUserTable();
            //int countexpected = expected.Count;

            //// Act
            //var result = container.GetAllUsers();
            //int countresult = result.Count;

            //// Assert
            //Assert.Equal(countexpected, countresult);            
        }

        [Fact]
        public void GetUserById_ShouldWork()
        {
            //// Arrange                                  
            //var users = TestDB.ReturnUserTable();
            //var expected = users.Where(i => i.Id == 1);

            //// Act
            //var result = container.GetUserById(1);
            
            //// Assert
            //Assert.NotNull(result);

            //foreach (var exp in expected)
            //{
            //    Assert.Equal(exp.Id, result.Id);
            //    Assert.Equal(exp.Name, result.Name);
            //    Assert.Equal(exp.Password, result.Password);
            //    Assert.Equal(exp.Email, result.Email);
            //    Assert.Equal(exp.IsActive, result.IsActive);
            //    Assert.Equal(exp.Age, result.Age);
            //    Assert.Equal(exp.Balance, result.Balance);
            //}
            
        }
    }
}