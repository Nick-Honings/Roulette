using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users.Eventargs
{
    public class NewUserEventArgs : EventArgs
    {
        public string NewUser { get; set; }

        public NewUserEventArgs(string userName)
        {
            this.NewUser = userName;
        }
    }
}
