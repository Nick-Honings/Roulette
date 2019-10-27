using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public interface IBet
    {
        string Name { get; set; }
        double Stake { get; set; }
        int Payout { get; }
        double GetReturnStake();
    }
}
