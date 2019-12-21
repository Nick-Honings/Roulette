using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory2.TestDAL
{
    public class TestNewsItemDAL
    {
        private List<INewsItemDTO> newsItems;

        public TestNewsItemDAL()
        {

            //newsItems = TestDB.ReturnNewsTable();
        }

        public bool Update(INewsItemDTO dto)
        {
            newsItems.Add(dto);
            return true;
        }
    }
}
