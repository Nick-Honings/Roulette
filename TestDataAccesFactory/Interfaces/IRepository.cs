using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;

namespace DataAccesFactory.Factory
{
    public interface IRepository
    {
        IBetDAL CreateBetDAL();
        INewsItemContainerDAL CreateNewsItemContainerDAL();
        INewsItemDAL CreateNewsItemDAL();
        IRoomContainerDAL CreateRoomContainerDAL();
        IRoomDAL CreateRoomDAL();
        IRoundDAL CreateRoundDAL();
        IUserContainerDAL CreateUserContainerDAL();
        IUserDAL CreateUserDAL();
        IAdminContainerDAL CreateAdminContainerDAL();
        IAdminDAL CreateAdminDAL();
    }
}