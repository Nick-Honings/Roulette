using InterfaceLayerBD;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestRoomContainerDAL : IRoomContainerDAL
    {
        private List<IRoomDTO> rooms;
        private List<IRoundDTO> rounds;
        private List<IPocketDTO> pockets;

        public TestRoomContainerDAL()
        {
            //rooms = TestDB.ReturnRoomTable();
            //rounds = TestDB.ReturnRoundTable();
            //pockets = TestDB.ReturnPocketTable();
        }

        public bool Delete(int id)
        {
            var room = rooms.Find(i => i.Id == id);
            rooms.Remove(room);
            return true;
        }

        public List<IRoomDTO> GetAllRooms()
        {
            foreach (var r in rounds)
            {
                var pocket = pockets.FindAll(i => i.Id == r.Id);                
            }
            
            return rooms;
        }

        public bool Save(IRoomDTO dto)
        {
            rooms.Add(dto);
            return true;
        }
    }
}
