using DataAccesFactory;
using InterfaceLayerBD.Bet;
using Roulette.Bets;
using Roulette.GameStructure;
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
        public void GetInfo_ShouldReturnPropNameAndValue()
        {
            // Arrange
            IBetDTO bet = new ColorBet(PocketColor.Black, null)
            {
                ID = 2,
                Stake = 20
            };


            // Act
            IBetDAL dal = Factory.CreateBetDAL();
            bool x = dal.Save(bet);
        }

        [Fact]
        public void GetInfo_ShouldReturnPropNameAndValue2()
        {
            // Arrange
            IBet bet = new ColorBet(PocketColor.Black, null)
            {
                ID = 1,
                Stake = 20
            };

            // Act
            var propsinfo = bet.GetInfo();

        }
    }
}
