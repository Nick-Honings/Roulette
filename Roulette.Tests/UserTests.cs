using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.Users;
using Roulette.Bets;
using Roulette.GameStructure;
using TestDataAccesFactory;
using InterfaceLayerBD.Bet;

namespace Roulette.Tests
{
    public class UserTests
    {
        User user;
        IBet bet;
        InMemRepository repo;

        public UserTests()
        {
            repo = new InMemRepository();
            user = new User("test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 100
            };
            bet = new ColorBet(IPocketColor.Black);
            
        }

        [Fact]
        public void MakeBet_ShouldWork()
        {
            // Arrange
            decimal expected = 10;

            // Act
            bet.Stake = 10;
            user.MakeBet(bet);
            decimal result = user.CurrentBet.Stake;
            

            // Assert
            Assert.Equal(expected, result);
            Assert.IsAssignableFrom<ColorBet>(user.CurrentBet);
        }
    }
}
