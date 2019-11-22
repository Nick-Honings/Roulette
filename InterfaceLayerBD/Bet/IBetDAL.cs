using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Bet
{
    public interface IBetDAL<T> where T: IColorBetDTO
    {
        bool Save(IBetDTO dto);
        void Insert(object[] param);
    }
}
