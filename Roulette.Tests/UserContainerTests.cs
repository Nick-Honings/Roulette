﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.Users;
using TestDataAccesFactory;
using TestDatabase.TestDatabase;

namespace Roulette.Tests
{
    public class UserContainerTests
    {
        UserContainer container;
        User user;
        User emptyUser;
        InMemRepository repo;

        public UserContainerTests()
        {
            repo = new InMemRepository();
            container = new UserContainer(repo.CreateUserContainerDAL(), repo.CreateUserDAL(), repo.CreateBetDAL());
            user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 15
            };
        }

        [Fact]
        public void AddUser_ShouldWork()
        {
            // Arrange
            int expected = TestDB.GetUserTable().Count + 1;           

            // Act
            bool validCall = container.AddUser(user);
            int result = container.Users.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.True(validCall);            
        }

        [Fact]
        public void AddUser_ShouldNotAddEmptyClass()
        {
            // Arrange
            int expected = TestDB.GetUserTable().Count;

            // Act
            bool validCall = container.AddUser(emptyUser);
            int result = container.Users.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }       
        
        
        [Fact]
        public void GetAllUsers_ShouldWork()
        {
            // Arrange
            int expected = TestDB.GetUserTable().Count;

            // Act
            var result = container.GetAllUsers();
            int resultCount = result.Count;

            // Assert
            Assert.Equal(expected, resultCount);       
        }


        [Fact]
        public void GetUserById_ShouldWork()
        {
            // Arrange
            var users = TestDB.GetUserTable();
            var expected = users.Where(i => i.Id == 1);

            // Act
            var result = container.GetUserById(1);

            // Assert
            Assert.NotNull(result);

            foreach (var exp in expected)
            {
                Assert.Equal(exp.Id, result.Id);
                Assert.Equal(exp.Name, result.Name);
                Assert.Equal(exp.Email, result.Email);
                Assert.Equal(exp.IsActive, result.IsActive);
                Assert.Equal(exp.Age, result.Age);
                Assert.Equal(exp.Balance, result.Balance);
            }
        }

        [Fact]
        public void GetUserById_ShouldReturnNull()
        { 
            // Act
            var result = container.GetUserById(111230);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            int expected = TestDB.GetUserTable().Count(i => i.UserRole == 2);
            container.AddUser(user);

            // Act
            bool validCall = container.RemoveUser(user.Id);
            int result = container.Users.Count;

            // Assert
            Assert.True(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveUser_ShouldNotAttemptRemoveInvalidId()
        {
            // Arrange
            int expected = TestDB.GetUserTable().Count(i => i.UserRole == 2);
            

            // Act
            bool validCall = container.RemoveUser(123654);
            int result = container.Users.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }
    }
}