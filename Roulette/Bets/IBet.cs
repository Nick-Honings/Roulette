using InterfaceLayerBD.Bet;
using Roulette.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public interface IBet
    {
        int Id { get; set; }
        decimal Stake { get; set; }
        double Odd { get; }
        BetType Type { get; set; }
        decimal GetReturnStake();
        Dictionary<string, object> GetBetSpecificInfo();

    }
}
