using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class EvenUnevenBet : IBet
    {
        public bool IsEven { get; set; }
        public double Stake { get; set; }
        public int Payout { get; } = 2;

        public EvenUnevenBet(bool isEven)
        {
            IsEven = isEven;
        }

        public double GetReturnStake()
        {
            return Stake * Payout;
        }
    }
}