using InterfaceLayerBD;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using Roulette.DAL.MYSQL;
using Roulette.DAL.MYSQL.News;
using Roulette.DAL.MYSQL.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static IRoomDAL CreateTestRoomDAL()
        {
            return new RoomDAL();
        }

        public static IRoomContainerDAL CreateTestRoomContainerDAL()
        {
            return new RoomDAL();
        }

        public static INewsItemContainerDAL CreateTestNewsItemContainerDAL()
        {
            return new NewsItemDAL();
        }

        public static INewsItemDAL CreateTestNewsItemDAL()
        {
            return new NewsItemDAL();
        }
    }
}
