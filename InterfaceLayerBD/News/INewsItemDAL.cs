using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.News
{
    public interface INewsItemDAL
    {
        bool Update(INewsItemDTO dto);
    }
}
