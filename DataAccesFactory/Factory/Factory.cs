using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using Roulette.DAL.MYSQL;
using Roulette.DAL.MYSQL.Bet;
using Roulette.DAL.MYSQL.News;
using Roulette.DAL.MYSQL.Room;

namespace DataAccesFactory
{
    public static class Factory
    {
        public static IUserDAL CreateUserDAL()
        {
            return new UserDAL();
        }

        public static IUserContainerDAL CreateUserContainerDal()
        {
            return new UserDAL();
        }

        public static IRoomDAL CreateRoomDAL()
        {
            return new RoomDAL();
        }

        public static IRoomContainerDAL CreateRoomContainerDAL()
        {
            return new RoomDAL();
        }

        public static INewsItemContainerDAL CreateNewsItemContainerDAL()
        {
            return new NewsItemDAL();
        }

        public static INewsItemDAL CreateNewsItemDAL()
        {
            return new NewsItemDAL();
        }

        public static IBetDAL CreateBetDAL()
        {
            return new BetDAL();
        }
    }
}