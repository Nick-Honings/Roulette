using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class SingleNumberBet : IBet
    {
        public int Number { get; set; }
        public double Stake { get; set; }
        public int Payout { get; } = 35;
        

        public double GetReturnStake()
        {
            return Stake * Payout;
        }
    }
}
