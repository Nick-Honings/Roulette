using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD.Bet;
using Roulette.Bets;
using Roulette.GameStructure;

namespace Roulette.Tests.TestData
{
    public static class RoomTestsData 
    {
        public class PositiveBets : IEnumerable<object[]>
        {
            IPocket r1 = new Pocket((IPocketNumber)26);
            IBet b1 = new ColorBet(IPocketColor.Black);
            double e1 = 20;

            IPocket r2 = new Pocket((IPocketNumber)12);
            IBet b2 = new EvenUnevenBet(true);
            
            double e2 = 20;

            IPocket r3 = new Pocket((IPocketNumber)29);
            IBet b3 = new NeighbourBet((IPocketNumber)29, (IPocketNumber)30);
            double e3 = 20;

            IPocket r4 = new Pocket((IPocketNumber)8);
            IBet b4 = new SingleNumberBet((IPocketNumber)8);
            double e4 = 350;

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { r1, b1, e1 };
                yield return new object[] { r2, b2, e2 };
                yield return new object[] { r3, b3, e3 };
                yield return new object[] { r4, b4, e4 };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class NegativeBets : IEnumerable<object[]>
        {
            IPocket r1 = new Pocket((IPocketNumber)12);
            IBet b1 = new ColorBet(IPocketColor.Black);
            double e1 = 0;

            IPocket r2 = new Pocket((IPocketNumber)11);
            IBet b2 = new EvenUnevenBet(true);
            double e2 = 0;

            IPocket r3 = new Pocket((IPocketNumber)29);
            IBet b3 = new NeighbourBet((IPocketNumber)15, (IPocketNumber)16);
            double e3 = 0;

            IPocket r4 = new Pocket((IPocketNumber)8);
            IBet b4 = new SingleNumberBet((IPocketNumber)15);
            double e4 = 0;

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { r1, b1, e1 };
                yield return new object[] { r2, b2, e2 };
                yield return new object[] { r3, b3, e3 };
                yield return new object[] { r4, b4, e4 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
