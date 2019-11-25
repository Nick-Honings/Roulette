using InterfaceLayerBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestUserContainerDAL : IUserContainerDAL
    {
        public bool Delete(int id)
        {
            return true;
        }

        public List<IUserDTO> GetAllUsers()
        {
            return new List<IUserDTO>();
        }

        public IUserDTO GetUserById(int id)
        {
            return null;
        }

        public bool Save(IUserDTO dto)
        {
            return true;
        }
    }
}
