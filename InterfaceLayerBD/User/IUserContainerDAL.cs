using System.Collections.Generic;
using InterfaceLayerBD;

namespace InterfaceLayerBD
{
    public interface IUserContainerDAL
    {
        bool DeleteUser(int id);
        List<IUserDTO> GetAllUsers();
        IUserDTO GetUserById(int id);
        bool AddUser(IUserDTO dto);
    }
}