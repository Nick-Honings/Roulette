using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class UserContainer
    {
        public List<User> Users { get; private set; }

        public UserContainer()
        {
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            if(user != null)
            {
                Users.Add(user);
            }
        }

        public void RemoveUser(User user)
        {
            if (user != null)
            {
                Users.Remove(user); 
            }
        }

    }
}
