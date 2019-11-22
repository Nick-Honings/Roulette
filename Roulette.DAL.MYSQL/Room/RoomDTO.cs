using InterfaceLayerBD.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Room
{
    public class RoomDTO : IRoomDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public int Capacity { get; set; }
        public double StakeUpLim { get; set; }
        public double StakeLowLim { get; set; }
        public int RoundTime { get; set; }
    }
}
