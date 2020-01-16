using InterfaceLayerBD.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Admin
{
    public class AdminDTO : IAdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
        public int UserRole { get; set; }
    }
}
