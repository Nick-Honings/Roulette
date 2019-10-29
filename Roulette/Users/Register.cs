using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class Register
    {
        public static User RegisterUser(string name, string password,string email, int age)
        {
            return new User(name)
            {                
                Password = password,
                Email = email,
                Age = age
            };
        }
    }
}
