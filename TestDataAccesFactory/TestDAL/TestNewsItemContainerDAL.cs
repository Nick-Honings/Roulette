using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory.TestDAL
{
    public class TestNewsItemContainerDAL : INewsItemContainerDAL
    {       
        private List<INewsItemDTO> news; 

        public TestNewsItemContainerDAL()
        {           
            news = TestDB.GetNewsTable();
        }

        public bool Delete(int id)
        {
            int index = news.FindIndex(i => i.Id == id);

            if (index != -1)
            {
                news.RemoveAt(index);
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
