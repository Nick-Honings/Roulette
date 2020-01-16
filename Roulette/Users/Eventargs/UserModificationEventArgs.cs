using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users.Eventargs
{
    public class UserModificationEventArgs : EventArgs
    {
        public int UserId { get; set; }

        public UserModificationEventArgs(int userId)
        {
            this.UserId = userId;
        }
    }
}
