using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class EvenUnevenBet : Bet, IBet, IBetDTO
    {
        public bool IsEven { get; set; }

        public EvenUnevenBet(bool isEven)
        {
            IsEven = isEven;
            Odd = 2;
            Type = BetType.EvenUneven;
        }
    }
}