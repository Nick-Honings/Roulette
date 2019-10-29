using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.Users;
using Roulette.Bets;

namespace Roulette.Tests
{
    public class UserTests
    {
        User user;
        IBet bet;

        public UserTests()
        {
            user = new User("test");
            bet = new ColorBet(Color.Black);
        }

        [Fact]
        public void MakeBet_ShouldWork()
        {
            // Arrange
            double expected = 10;

            // Act
            user.MakeBet(bet, 10);
            double result = user.CurrentBet.Stake;
            

            // Assert
            Assert.Equal(expected, result);
            Assert.IsAssignableFrom<ColorBet>(user.CurrentBet);
        }
    }
}
