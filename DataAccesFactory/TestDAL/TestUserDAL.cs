using InterfaceLayerBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestUserDAL : IUserDAL
    {
        public bool Update(IUserDTO dto)
        {
            return true;
        }
    }
}
