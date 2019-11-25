using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestNewsItemContainerDAL : INewsItemContainerDAL
    {
        public bool Delete(int id)
        {
            return true;
        }

        public List<INewsItemDTO> GetAllNewsItems()
        {
            return null;
        }

        public bool Save(INewsItemDTO dto)
        {
            return true;
        }
    }
}
