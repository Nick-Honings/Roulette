using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class EvenUnevenBet : Bet, IBet
    {
        public bool IsEven { get; set; }

        public EvenUnevenBet(bool isEven)
        {
            IsEven = isEven;
            this.Odd = 2;
        }
    }
}