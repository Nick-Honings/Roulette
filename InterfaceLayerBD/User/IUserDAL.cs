using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD
{
    public interface IUserDAL
    {
        bool UpdateProfile(IUserDTO dto);
        bool UpdateBalance(int id, decimal balance);
        int VerifyLogin(string username, string password);
    }
}
