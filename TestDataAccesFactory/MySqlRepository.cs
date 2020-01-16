using DataAccesFactory.Factory;
using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using Roulette.DAL.MYSQL;
using Roulette.DAL.MYSQL.Admin;
using Roulette.DAL.MYSQL.Bet;
using Roulette.DAL.MYSQL.News;
using Roulette.DAL.MYSQL.Room;
using Roulette.DAL.MYSQL.Round;
using TestDataAccesFactory.Interfaces;

namespace TestDataAccesFactory
{
    public class MySqlRepository : IRepository, IBetRepository, IUserContainerRepository, IRoomContainerRepository, IAdminRepository, INewsItemRepository
    {
        private readonly string _connString;

        public MySqlRepository()
        {
            this._connString = ConnectionHelper.CnnVal("TestDatabase");
        }
        public IUserDAL CreateUserDAL()
        {            
            return new UserDAL(_connString);
        }

        public IUserContainerDAL CreateUserContainerDal()
        {
            return new UserDAL(_connString);
        }

        public IRoomDAL CreateRoomDAL()
        {
            return new RoomDAL(_connString);
        }

        public IRoomContainerDAL CreateRoomContainerDAL()
        {
            return new RoomDAL(_connString);
        }

        public INewsItemContainerDAL CreateNewsItemContainerDAL()
        {
            return new NewsItemDAL(_connString);
        }

        public INewsItemDAL CreateNewsItemDAL()
        {
            return new NewsItemDAL(_connString);
        }

        public IBetDAL CreateBetDAL()
        {
            return new BetDAL(_connString);
        }

        public IUserContainerDAL CreateUserContainerDAL()
        {
            return new UserDAL(_connString);
        }


        public IAdminContainerDAL CreateAdminContainerDAL()
        {
            return new AdminDAL(_connString);
        }

        public IAdminDAL CreateAdminDAL()
        {
            return new AdminDAL(_connString);
        }

        public IRoundDAL CreateRoundDAL()
        {
            return new RoundDAL(_connString);
        }
    }
}