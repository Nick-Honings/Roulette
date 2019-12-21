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
        private List<INewsItemDTO> news; 

        public TestNewsItemContainerDAL()
        {           
            //news = TestDBREAL.ReturnNewsTable();
        }

        public bool Delete(int id)
        {
            var newsitem = news.Find(i => i.Id == id);

            if(newsitem != null)
            {
                news.Remove(newsitem);
                return true;
            }
            return false;
        }

        public List<INewsItemDTO> GetAllNewsItems()
        {
            return news;
        }

        public bool Save(INewsItemDTO dto)
        {
            news.Add(dto);
            return true;
        }
    }
}
