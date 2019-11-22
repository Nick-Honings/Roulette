﻿using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.News
{
    public class NewsItem : INewsItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }

        private INewsItemDAL newItemDAL;

        public NewsItem(string title, INewsItemDAL dAL)
        {
            Title = title;
            newItemDAL = dAL;
            date = DateTime.Now.ToLocalTime();
        }


    }
}
