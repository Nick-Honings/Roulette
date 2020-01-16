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
    public class ColorBet : Bet, IBet, IBetDTO
    {
        // Use
        public IPocketColor Color { get; private set; }        

        public ColorBet(IPocketColor color)
        {
            Color = color;
            this.Type = BetType.Color;            
            this.Odd = 2;            
        }
    }
}
