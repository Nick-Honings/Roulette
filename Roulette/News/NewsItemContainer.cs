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
        // Dependencies
        private readonly INewsItemContainerDAL _containerDAL;
        private readonly INewsItemDAL _newsItemDAL;

        public List<NewsItem> NewsItems { get; private set; }
        public int Index { get; private set; } = 0;

        public NewsItemContainer(INewsItemContainerDAL containerDAL, INewsItemDAL newsItemDAL)
        {
            NewsItems = new List<NewsItem>();
            this._containerDAL = containerDAL;
            this._newsItemDAL = newsItemDAL;
            this.NewsItems = this.GetAllNewsItems();
        }

        public bool AddNewsItem(NewsItem news)
        {
            if (news != null)
            {                         
                if(_containerDAL.Save(news))
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
                if(_containerDAL.Delete(news.Id))
                {
                    int index = NewsItems.FindIndex(i => i.Id == news.Id);
                    NewsItems.RemoveAt(index);
                    return true;
                }                
            }
            return false;
        }

        public List<NewsItem> GetAllNewsItems()
        {
            List<NewsItem> newsItems = new List<NewsItem>();
            var dtos = _containerDAL.GetAllNewsItems();
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
            return new NewsItem(dto.Title, _newsItemDAL)
            {
                Id = dto.Id,
                Description = dto.Description,
                date = dto.date
            };
        }
    }
}