using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Admin
{
    public interface IAdminContainerDAL
    {
        List<IAdminDTO> GetAllAdmins();
    }
}
