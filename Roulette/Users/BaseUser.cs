using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class BaseUser
    {
        public string Name { get; internal set; }
        public string Password { get; set; }

        public bool VerifyLogin()
        {
            throw new NotImplementedException();
        }
    }
}
