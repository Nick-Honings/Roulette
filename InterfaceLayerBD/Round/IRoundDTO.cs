using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Round
{
    public interface IRoundDTO
    {
        int Id { get; set; }
        bool HasEnded { get; set; }
        int RoomId { get; set; }
    }
}
