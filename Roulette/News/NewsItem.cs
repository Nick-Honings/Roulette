using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.News
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Description { get; private set; }
        public DateTime date { get; private set; }


        public NewsItem(string title)
        {
            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description;
            date = DateTime.Now.ToLocalTime();
        }
    }
}
