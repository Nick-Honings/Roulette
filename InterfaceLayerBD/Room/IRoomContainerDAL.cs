using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Room
{
    public interface IRoomContainerDAL
    {
        bool Save(IRoomDTO dto);
        bool Delete(int id);
        List<IRoomDTO> GetAllRooms();
    }
}
