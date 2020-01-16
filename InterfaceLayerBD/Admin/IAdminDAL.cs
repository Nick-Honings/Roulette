using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Admin
{
    public interface IAdminDAL
    {
        bool AddUser(IUserDTO dto);
        bool DeleteUser(int index);
        bool DisableUser(int id);
        bool SetUserBalance(int id, decimal balance);
        bool EnableUser(int id);
        int VerifyLogin(string username, string password);
        DataSet GetUserAndBetDetails();

    }
}
