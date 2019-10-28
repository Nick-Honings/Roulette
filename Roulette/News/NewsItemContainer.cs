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

        public NewsItemContainer()
        {
            NewsItems = new List<NewsItem>();
        }

        public void AddNewsItem(NewsItem news)
        {
            if (news != null)
            {
                NewsItems.Add(news);
            }
        }


        public void RemoveNewsItem(NewsItem news)
        {
            if (news != null)
            {
                NewsItems.Remove(news); 
            }
        }

        public NewsItem GetNextNewsItem()
        {
            NewsItem output = NewsItems[Index];
            Index++;
            return output;
        }
    }
}