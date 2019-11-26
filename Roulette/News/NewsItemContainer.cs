using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.News
{
    public class NewsItemContainer
    {
        public List<NewsItem> NewsItems { get; private set; }
        public int Index { get; private set; } = 0;

        private INewsItemContainerDAL containerDAL;

        public NewsItemContainer(INewsItemContainerDAL dAL)
        {
            NewsItems = new List<NewsItem>();
            containerDAL = dAL;
        }

        public bool AddNewsItem(NewsItem news)
        {
            if (news != null)
            {                         
                INewsItemDTO dTO = news;               

                if(containerDAL.Save(dTO))
                {
                    NewsItems.Add(news);
                    return true;
                }                
            }
            return false;
        }


        public bool RemoveNewsItem(NewsItem news)
        {
            if (news != null)
            {
                NewsItems.Remove(news);
                if(containerDAL.Delete(news.Id))
                {
                    return true;
                }                
            }
            return false;
        }

        public List<NewsItem> GetAll()
        {
            List<NewsItem> newsItems = new List<NewsItem>();
            var dtos = containerDAL.GetAllNewsItems();
            foreach (var d in dtos)
            {
                newsItems.Add(ExtractNewsItem(d));
            }
            return newsItems;
        }

        public NewsItem GetNextNewsItem()
        {
            NewsItem output = NewsItems[Index];
            Index++;
            return output;
        }

        private NewsItem ExtractNewsItem(INewsItemDTO dto)
        {
            return new NewsItem(dto.Title, null)
            {
                Id = dto.Id,
                Description = dto.Description,
                date = dto.date
            };
        }
    }
}