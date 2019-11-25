using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestNewsItemDAL : INewsItemDAL
    {
        public bool Update(INewsItemDTO dto)
        {
            return true;
        }
    }
}
