using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Room
{
    public interface IRoomDTO
    {
        int Id { get; }
        string Name { get; }
        int Capacity { get; set; } 
        double StakeUpLim { get; set; } 
        double StakeLowLim { get; set; } 
        int RoundTime { get; set; } 
    }
}
