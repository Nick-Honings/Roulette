using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.News
{
    public interface INewsItemContainerDAL
    {
        bool Save(INewsItemDTO dto);
        bool Delete(int id);
        List<INewsItemDTO> GetAllNewsItems();
    }
}
