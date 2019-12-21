using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class SingleNumberBet : Bet, IBet
    {
        // Use
        public PocketNumber PocketNumber { get; private set; }

        public SingleNumberBet(PocketNumber number)
        {
            PocketNumber = number;
            this.Odd = 35;
        }
    }
}
