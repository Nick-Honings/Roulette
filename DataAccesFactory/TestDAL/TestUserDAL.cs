using InterfaceLayerBD;
using InterfaceLayerBD.Bet;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestUserDAL : IUserDAL
    {
        private List<IUserDTO> users;

        public TestUserDAL()
        {
            //users = TestDB.ReturnUserTable();
        }

        public bool Insert<T>(object[] param)
        {
            //Save bet
            return true;
        }

        public bool Save(IBetDTO dto)
        {
            // Add bet.
            return true;
        }

        public bool Update(IUserDTO dto)
        {
            int index = users.FindIndex(i => i.Id == dto.Id);
            users[index] = dto;
            return true;
        }
    }
}
