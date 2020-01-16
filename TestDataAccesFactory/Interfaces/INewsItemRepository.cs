using InterfaceLayerBD.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccesFactory.Interfaces
{
    public interface INewsItemRepository
    {
        INewsItemContainerDAL CreateNewsItemContainerDAL();
        INewsItemDAL CreateNewsItemDAL();
    }
}
