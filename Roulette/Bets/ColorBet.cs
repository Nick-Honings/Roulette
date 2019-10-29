using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class ColorBet : IBet
    {
        public Color Color { get; private set; }
        public double Stake { get; set; }
        public int Payout { get; } = 2;

        public ColorBet(Color color)
        {
            Color = color;
        }
        public double GetReturnStake()
        {
            return Stake * Payout;
        }
    }
}
