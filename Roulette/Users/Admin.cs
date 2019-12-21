using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class Admin : BaseUser
    {
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DisableUser(User user)
        {
            user.IsActive = false;
        }

        public void SetUserBalance(User user, decimal balance)
        {
            user.Balance = balance;
        }
    }
}
