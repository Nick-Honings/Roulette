using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Admin
{
    public interface IAdminDTO
    {
        int Id { get; set; }
        string Name { get; set; }
        List<string> Permissions { get; set; }
        int UserRole { get; set; }
    }
}
