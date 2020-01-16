using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccesFactory.Interfaces
{
    public interface IRoomContainerRepository
    {
        IRoomContainerDAL CreateRoomContainerDAL();
        IRoundDAL CreateRoundDAL();
        IRoomDAL CreateRoomDAL();
    }
}
