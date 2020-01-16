using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class AdminContainer
    {
        public List<Admin> Admins { get; private set; }

        private readonly IAdminContainerDAL _containerDal;
        private readonly IAdminDAL _adminDAL;

        public AdminContainer(IAdminContainerDAL containerDAL, IAdminDAL adminDAL)
        {
            this._containerDal = containerDAL;
            this._adminDAL = adminDAL;
            Admins = this.GetAllAdmins();
        }

        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();
            var dtos = _containerDal.GetAllAdmins();
            foreach (var d in dtos)
            {
                Admin admin = ExtractAdmin(d);
                admins.Add(admin);
            }
            return admins;
        }

        private Admin ExtractAdmin(IAdminDTO dto)
        {
            if (dto != null)
            {
                return new Admin(_adminDAL)
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Permissions = dto.Permissions,
                    UserRole = dto.UserRole
                };
            }
            return null;
        }
    }
}
