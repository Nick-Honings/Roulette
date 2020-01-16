using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        //public UserRole UserRole { get; set; }
        public int UserRole { get; set; }
        public List<string> Permissions { get; set; }



        //public bool VerifyLogin(IUserDAL userDAL = null, IAdminDAL adminDAL = null)
        //{
        //    if(userDAL != null)
        //    {
        //        return userDAL.VerifyLogin(this.Name, this.Password);
        //    }
        //    else if(userDAL != null)
        //    {
        //        return adminDAL.VerifyLogin(this.Name, this.Password);
        //    }
        //    // Throw exception?
        //    return false;
        //}
    }
}
