﻿using InterfaceLayerBD.Bet;
using Roulette;
using Roulette.Bets;
using Roulette.Users;
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
    public class UserTests
    {
        private UserContainer container;
        private MySqlRepository repo;

        public UserTests()
        {
            repo = new MySqlRepository();
           
        }

        [Fact]
        public void GetAllUsers_ShouldWork()
        {
            // Arrange
            int expected = 3;
            List<User> expectedUsers = new List<User>()
            {
                new User("NickTEST", null, null)
                {
                    Id = 1,
                    Email = "nick.honings@gmail.com",
                    Age = 21,
                    IsActive = true,
                    Balance = 200
                },
                new User("Test", null, null)
                {
                    Id = 2,
                    Email = "test@test.com",
                    Age = 50,
                    IsActive = true,
                    Balance = 100
                },
                new User("Piet", null, null)
                {
                    Id = 3,
                    Email = "tdkf@gmail.com",
                    Age = 24,
                    IsActive = true,
                    Balance = 300
                }
            };


            // Act
            using (TransactionScope scope = new TransactionScope())
            {
                container = new UserContainer(repo.CreateUserContainerDal(), repo.CreateUserDAL(), repo.CreateBetDAL());

                var resultUsers = container.Users;
                int resultCount = resultUsers.Count;

                // Assert
                Assert.Equal(expected, resultCount);


                for (int i = 0; i < expectedUsers.Count; i++)
                {
                    Assert.Equal(expectedUsers[i].Id, resultUsers[i].Id);
                    Assert.Equal(expectedUsers[i].Name, resultUsers[i].Name);
                    Assert.Equal(expectedUsers[i].Email, resultUsers[i].Email);
                    Assert.Equal(expectedUsers[i].Age, resultUsers[i].Age);
                    Assert.Equal(expectedUsers[i].IsActive, resultUsers[i].IsActive);
                    Assert.Equal(expectedUsers[i].Balance, resultUsers[i].Balance);
                }
            }
        }

        [Fact]
        public void AddUser_ShouldWork()
        {
            // Arrange
            int expected = 4;
            container = new UserContainer(repo.CreateUserContainerDal(), repo.CreateUserDAL(), repo.CreateBetDAL());

            User toAdd = new User("Pablo", null, null)
            {
                Id = 13,
            };

            bool validCall;
            // Act
            using (TransactionScope scope = new TransactionScope())
            {
                validCall = container.AddUser(toAdd);


                // Assert
                Assert.True(validCall);
                Assert.Equal(expected, container.Users.Count);
            }
        }

        [Fact]
        public void RemoveUser_ShouldWork()
        {
            // Arrange
            int expected = 2;
            container = new UserContainer(repo.CreateUserContainerDal(), repo.CreateUserDAL(), repo.CreateBetDAL());


            using (TransactionScope scope = new TransactionScope())
            {                

                // Act
                bool validCall = container.RemoveUser(1);

                // Assert
                Assert.True(validCall);
                Assert.Equal(expected, container.GetAllUsers().Count);
                Assert.Equal(expected, container.Users.Count);
            }

        }


    }
}
