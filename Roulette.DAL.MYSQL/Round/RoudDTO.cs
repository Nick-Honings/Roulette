using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Round
{
    public class RoudDTO: IRoundDTO
    {
        public int Id { get; set; }
        public bool HasEnded { get; set; }
        public int RoomId { get; set; }
    }
}
