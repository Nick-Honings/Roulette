using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class NeighbourBet : Bet, IBet
    {
        // Use
        public PocketNumber FirstNumber { get;  private set; }
        public PocketNumber SecondNumber { get; private set; }

        public NeighbourBet(PocketNumber firstNumber, PocketNumber secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            this.Odd = 0.054;
        }
    }
}
