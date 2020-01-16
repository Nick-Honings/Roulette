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
    public class NeighbourBet : Bet, IBet, IBetDTO
    {
        // Use
        public IPocketNumber FirstNumber { get;  private set; }
        public IPocketNumber SecondNumber { get; private set; }

        

        public NeighbourBet(IPocketNumber firstNumber, IPocketNumber secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            this.Odd = 2;
            Type = BetType.Neighbour;
        }
    }
}
