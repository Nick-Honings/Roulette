using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using Roulette.Users.Eventargs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class Admin : BaseUser, IAdminDTO
    {
        private readonly IAdminDAL _adminDAL;

        // Subscribe to this event to get notified of newly added users.
        public event EventHandler<NewUserEventArgs> NewUserAdded;

        // Subscribe to this event to get notified of user modifications.
        public event EventHandler<UserModificationEventArgs> UserModification;

        public Admin(IAdminDAL adminDAL)
        {
            this._adminDAL = adminDAL;       
            
            Permissions = new List<string>();
            UserRole = 1;            
        }

        public bool AddUser(User user)
        {
            if (user != null)
            {
                if (_adminDAL.AddUser(user))
                {
                    // Raise an event to notify usercontainer to get all users again.
                    this.NewUser(user.Name);
                    return true;
                }                
            }
            return false;
        }

        public bool RemoveUser(int id)
        {
            if (_adminDAL.DeleteUser(id))
            {
                this.NewUser("");
                return true;
            }
            
            return false;
        }

        public bool EnableUser(int id)
        {
            if (_adminDAL.EnableUser(id))
            {
                this.NewUserModification(id);
                return true;
            }
            return false;
        }

        public bool DisableUser(int id)
        {
            if (_adminDAL.DisableUser(id))
            {
                this.NewUserModification(id);
                return true;
            } 
            
            return false;
        }

        public bool SetUserBalance(int id, decimal balance)
        {
            if (_adminDAL.SetUserBalance(id, balance))
            {
                this.NewUserModification(id);
                return true;
            } 
            
            return false;
        }

        private void NewUser(string userName)
        {
            if(NewUserAdded != null)
            {
                NewUserAdded(this, new NewUserEventArgs(userName));
            }
        }

        private void NewUserModification(int id)
        {
            if(UserModification != null)
            {
                UserModification(this, new UserModificationEventArgs(id));
            }
        }
    }
}
