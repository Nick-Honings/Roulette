using InterfaceLayerBD;
using Roulette.DAL.MYSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestUserContainerDAL : IUserContainerDAL
    {
        
        private List<IUserDTO> users;

        public TestUserContainerDAL()
        {
            users = TestDB.ReturnUserTable();
        }

        
        public List<IUserDTO> GetUsers()
        {
            return users;
        }

        public bool Delete(int id)
        {
            foreach (var u in users)
            {
                if(u.Id == id)
                {
                    users.Remove(u);
                    return true;
                }
            }
            return false;
        }

        public List<IUserDTO> GetAllUsers()
        {
            return users;
        }

        public IUserDTO GetUserById(int id)
        {
            foreach (var u in users)
            {
                if(u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }

        public bool Save(IUserDTO dto)
        {
            users.Add(dto);
            return true;
        }
    }
}
