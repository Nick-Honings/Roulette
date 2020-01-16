using InterfaceLayerBD.Bet;
using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class SingleNumberBet : Bet, IBet, IBetDTO
    {
        // Use
        public IPocketNumber Number { get; private set; }

        public SingleNumberBet(IPocketNumber number)
        {
            Number = number;
            this.Odd = 35;
            Type = BetType.Single;
        }
    }
}
