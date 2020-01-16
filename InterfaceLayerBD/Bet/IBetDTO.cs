using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Bet
{
    public interface IBetDTO
    {
        int Id { get; set; }
        decimal Stake { get; set; }
        double Odd { get; }
        //This is the pocketcolor enum

        Dictionary<string, object> GetBetSpecificInfo();
    }
}
