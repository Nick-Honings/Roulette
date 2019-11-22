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
        double Stake { get; set; }
        double Odd { get; set; }
        //This is the pocketcolor enum
        int Color { get; set; }
        int Number { get; set; }
        bool Even { get; set; }
        int FirstNumber { get; set; }
        int LastNumber { get; set; }
    }
}
