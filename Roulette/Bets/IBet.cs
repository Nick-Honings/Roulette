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
        double Stake { get; set; }
        int Odd { get; }
        double GetReturnStake();
        

        //Function for returning bet info
    }
}
