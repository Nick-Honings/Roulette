using Roulette.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roulette.Tests
{
    public class BetTests
    {
        [Fact]
        public void Update_ShouldMakeValidCall()
        {
            // Arrange
            bool validCall = false;
            ColorBet colorBet = new ColorBet(Color.Black, null)
            {
                Stake = 20
            };

            // Act
            colorBet.Update();
            validCall = true;

            // Assert
            Assert.True(validCall);
        }
    }
}
