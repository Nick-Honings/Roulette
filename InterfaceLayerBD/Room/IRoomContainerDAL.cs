using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Room
{
    public interface IRoomContainerDAL
    {
        bool AddRoom(IRoomDTO dto);
        bool DeleteRoom(int id);
        List<IRoomDTO> GetAllRooms();
    }
}
