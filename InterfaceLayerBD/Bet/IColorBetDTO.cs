using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Bet
{
    public interface IColorBetDTO
    {
        // Color value, must be enum
        int Color { get; set; }
        double Stake { get; set; }
        int Payout { get; }
    }
}
