using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Bet
{
    public interface IBetDAL
    {
        bool Save(IBetDTO dto);
        bool Insert<T>(object[] param);
    }
}
