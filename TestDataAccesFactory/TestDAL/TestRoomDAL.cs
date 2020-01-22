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
    public class TestRoomDAL : IRoomDAL
    {
        private List<IRoomDTO> rooms;

        private List<IRoundDTO> rounds;

        private List<IUserDTO> users;

        public TestRoomDAL()
        {
            rooms = TestDB.GetRoomsTable();
            rounds = TestDB.GetRoundsTable();            
            users = TestDB.GetUserTable();
        }


        public List<IRoundDTO> GetAllRounds(int id)
        {
            return rounds.Where(i => i.RoomId == id).ToList();            
        }

        public List<IUserDTO> GetAllUsers(int roomid)
        {
            return users.Where(i => i.RoomId == roomid).ToList();
        }

        public bool SaveRound(IRoundDTO dto)
        {
            rounds.Add(dto);
            return true;
        }

        public bool Update(IRoomDTO dto)
        {
            int index = rooms.FindIndex(i => i.Id == dto.Id);
            if (index != -1)
            {
                rooms[index] = dto;
                return true; 
            }
            return false;
        }

        public bool AddUser(int id, int roomid)
        {
            var user = users.Find(i => i.Id == id);
            if (user != null)
            {
                user.RoomId = roomid;
                return true; 
            }
            return false;
        }

        public bool RemoveUser(int id, int roomid)
        {
            var userIndex = users.FindIndex(i => i.Id == id);
            if (userIndex != -1)
            {
                users[userIndex].RoomId = 0;
                return true; 
            }
            return false;
        }
    }
}
