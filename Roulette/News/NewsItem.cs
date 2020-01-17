using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.News
{
    public class NewsItem : INewsItemDTO
    {
        private readonly INewsItemDAL _newItemDAL;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        

        public NewsItem(string title, INewsItemDAL newsitemDAL)
        {
            this.Title = title;
            this._newItemDAL = newsitemDAL;
            this.PostDate = DateTime.Now.ToLocalTime();
        }

        public void SetDescription(string description)
        {
            this.Description = description;
        }

        public bool Update()
        {
            if (_newItemDAL.Update(this))
            {
                return true;
            }
            return false;
        }


    }
}
