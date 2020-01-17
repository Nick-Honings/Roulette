using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.News
{
    public interface INewsItemDTO
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime PostDate { get; set; }
    }
}
