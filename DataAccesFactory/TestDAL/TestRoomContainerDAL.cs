using InterfaceLayerBD.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestRoomContainerDAL : IRoomContainerDAL
    {
        public bool Delete(int id)
        {
            return true;
        }

        public List<IRoomDTO> GetAllRooms()
        {
            return null;
        }

        public bool Save(IRoomDTO dto)
        {
            return true;
        }
    }
}
