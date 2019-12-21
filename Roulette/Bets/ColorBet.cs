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
    public class ColorBet : Bet, IBet
    {
        // Use
        public PocketColor Color { get; private set; }


        private IBetDAL betDAL;

        public ColorBet(PocketColor color, IBetDAL dAL)
        {
            Color = color;
            betDAL = dAL;
            this.Odd = 2;
        }
    }
}
