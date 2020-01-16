using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Bet
{
    public interface INeighbourBet
    {
        IPocketNumber FirstNumber { get; }
        IPocketNumber SecondNumber { get; }
    }
}
