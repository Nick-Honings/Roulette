using InterfaceLayerBD;
using InterfaceLayerBD.Bet;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory
{
    public class TestUserDAL : IUserDAL
    {
        private List<IUserDTO> users;

        public TestUserDAL()
        {
            users = TestDataBase.GetUserTable();
        }

        public bool UpdateBalance(int id, decimal balance)
        {
            int index = users.FindIndex(i => i.Id == id);
            users[index].Balance = balance;
            return true;
        }

        public bool UpdateProfile(IUserDTO dto)
        {
            int index = users.FindIndex(i => i.Id == dto.Id);
            users[index] = dto;
            return true;
        }

        public int VerifyLogin(string username, string password)
        {
            var user = users.Find(i => i.Name == username && i.Password == password);

            if(user != null)
            {
                return user.Id;
            }
            return user.Id;
        }
    }
}
