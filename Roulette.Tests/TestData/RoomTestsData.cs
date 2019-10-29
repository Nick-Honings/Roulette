using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Bets;

namespace Roulette.Tests.TestData
{
    public class RoomTestsData 
    {
        public class PositiveBets : IEnumerable<object[]>
        {

            Result r1 = new Result(Color.Black, 26);
            IBet b1 = new ColorBet(Color.Black);
            double e1 = 20;

            Result r2 = new Result(Color.Red, 12);
            IBet b2 = new EvenUnevenBet(true);
            double e2 = 20;

            Result r3 = new Result(Color.Black, 29);
            IBet b3 = new NeighbourBet(29, 30);
            double e3 = 20;

            Result r4 = new Result(Color.Black, 8);
            IBet b4 = new SingleNumberBet(8);
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
            Result r1 = new Result(Color.Red, 12);
            IBet b1 = new ColorBet(Color.Black);
            double e1 = 0;

            Result r2 = new Result(Color.Red, 11);
            IBet b2 = new EvenUnevenBet(true);
            double e2 = 0;

            Result r3 = new Result(Color.Black, 29);
            IBet b3 = new NeighbourBet(15, 16);
            double e3 = 0;

            Result r4 = new Result(Color.Black, 8);
            IBet b4 = new SingleNumberBet(15);
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
