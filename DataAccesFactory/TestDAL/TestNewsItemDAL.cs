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
        private List<INewsItemDTO> newsItems;        

        public TestNewsItemDAL()
        {            
            newsItems = TestDB.ReturnNewsTable();
        }

        public bool Update(INewsItemDTO dto)
        {
            newsItems.Add(dto);
            return true;
        }
    }
}
