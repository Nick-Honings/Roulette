using InterfaceLayerBD.Bet;
using Roulette;
using Roulette.Bets;
using Roulette.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataAccesFactory;
using Xunit;

namespace LogicDALIntegration.Tests
{
    public class UserTests
    {
        UserContainer container;
        MySqlRepository repo;

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
                new User("Nick", null, null)
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


        [Fact]
        public void PlaceBet_ShouldWork()
        {
            // Arrange
            User user = new User("Nick", repo.CreateUserDAL(), repo.CreateBetDAL());
            IBet colorBet = new ColorBet(IPocketColor.Black)
            {
                Id = 100,
                Stake = 200
            };


            // Act
            user.MakeBet(new ColorBet(IPocketColor.Black));

            // Assert
        }
    }
}
