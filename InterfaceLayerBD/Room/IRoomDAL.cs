using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Room
{
    public interface IRoomDAL
    {
        bool Update(IRoomDTO dto);
        bool SaveRound(IRoundDTO dto);
        List<IUserDTO> GetAllUsers(int roomid);
        List<IRoundDTO> GetAllRounds(int roomid);
        bool AddUser(int id, int roomid);
        bool RemoveUser(int id, int roomid);
    }
}
