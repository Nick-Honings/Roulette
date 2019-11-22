using System.Collections.Generic;
using InterfaceLayerBD;

namespace InterfaceLayerBD
{
    public interface IUserContainerDAL
    {
        bool Delete(int id);
        List<IUserDTO> GetAllUsers();
        IUserDTO GetUserById(int id);
        bool Save(IUserDTO dto);
    }
}