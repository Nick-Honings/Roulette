using InterfaceLayerBD.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestRoomDAL : IRoomDAL
    {
        public bool Update(IRoomDTO dto)
        {
            return true;
        }
    }
}
