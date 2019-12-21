using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Round
{
    public interface IRoundDAL
    {
        bool Update(IRoundDTO dto);

        bool SavePocket(IPocketDTO dto);
    }
}
