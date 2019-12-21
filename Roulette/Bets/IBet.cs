using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public interface IBet : IBetDTO
    {
        int ID { get; set; }
        decimal Stake { get; set; }
        double Odd { get; }
        decimal GetReturnStake();
    }
}
