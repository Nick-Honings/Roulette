using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using Roulette.DAL.MYSQL.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory.TestDAL
{
    public class TestAdminDAL: IAdminDAL
    {
        private List<IUserDTO> users;

        public TestAdminDAL()
        {
            users = TestDataBase.GetUserTable();
        }

        public bool AddUser(IUserDTO dto)
        {
            users.Add(dto);
            return true;
        }

        public bool DeleteUser(int id)
        {
            try
            {
                int index = users.FindIndex(i => i.Id == id);
                users.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EnableUser(int id)
        {
            try
            {
                int index = users.FindIndex(i => i.Id == id);
                users[index].IsActive = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DisableUser(int id)
        {
            try
            {
                int index = users.FindIndex(i => i.Id == id);
                users[index].IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetUserBalance(int id, decimal balance)
        {
            try
            {
                int index = users.FindIndex(i => i.Id == id);
                users[index].Balance = balance;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int VerifyLogin(string username, string password)
        {
            var admin = (AdminDTO)users.Find(i => i.Name == username && i.Password == password);

            if (admin != null)
            {
                return admin.Id;
            }
            return admin.Id;
        }

        public DataSet GetUserAndBetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
