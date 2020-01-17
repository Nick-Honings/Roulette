using InterfaceLayerBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory
{
    public class TestUserContainerDAL : IUserContainerDAL
    {
        
        private List<IUserDTO> users;

        public TestUserContainerDAL()
        {
            users = TestDB.GetUserTable();
        }

        public bool DeleteUser(int id)
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
            var us = users.Where(i => i.UserRole == 2).ToList();
            return us;
        }


        public IUserDTO GetUserById(int id)
        {
            return users.Find(i => i.Id == id);
        }

        public bool AddUser(IUserDTO dto)
        {
            users.Add(dto);
            return true;
        }
    }
}
