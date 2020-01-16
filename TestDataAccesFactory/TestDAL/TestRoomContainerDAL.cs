using InterfaceLayerBD;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory.TestDAL
{
    public class TestRoomContainerDAL : IRoomContainerDAL
    {
        private List<IRoomDTO> rooms;

        public TestRoomContainerDAL()
        {
            rooms = TestDataBase.GetRoomsTable();
        }

        public bool DeleteRoom(int id)
        {
            int index = rooms.FindIndex(i => i.Id == id);

            if (index != -1)
            {
                rooms.RemoveAt(index);
                return true;
            }
            return false;
        }

        public List<IRoomDTO> GetAllRooms()
        {           
            return rooms;
        }

        public bool AddRoom(IRoomDTO dto)
        {
            rooms.Add(dto);
            return true;
        }
    }
}
