using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestRoomDAL : IRoomRoundDAL
    {
        private List<IRoomDTO> rooms;

        private List<IRoundDTO> rounds;

        public TestRoomDAL()
        {
            //rooms = TestDB.ReturnRoomTable();
            //rounds = TestDB.ReturnRoundTable();
        }

        public bool Save(IRoundDTO dto)
        {
            rounds.Add(dto);
            return true;
        }

        public bool Update(IRoomDTO dto)
        {
            int index = rooms.FindIndex(i => i.Id == dto.Id);
            rooms[index] = dto;
            return true;
        }
    }
}
