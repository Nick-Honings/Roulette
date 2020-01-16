using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using Roulette.DAL.MYSQL;
using Roulette.DAL.MYSQL.Bet;
using Roulette.DAL.MYSQL.News;
using Roulette.DAL.MYSQL.Room;

namespace DataAccesFactory.Factory
{
    public class MySqlRepository : IRepository
    {
        public IUserDAL CreateUserDAL()
        {
            return new UserDAL();
        }

        public IUserContainerDAL CreateUserContainerDal()
        {
            return new UserDAL();
        }

        public IRoomDAL CreateRoomDAL()
        {
            return new RoomDAL();
        }

        public IRoomContainerDAL CreateRoomContainerDAL()
        {
            return new RoomDAL();
        }

        public INewsItemContainerDAL CreateNewsItemContainerDAL()
        {
            return new NewsItemDAL();
        }

        public INewsItemDAL CreateNewsItemDAL()
        {
            return new NewsItemDAL();
        }

        public IBetDAL CreateBetDAL()
        {
            return new BetDAL();
        }

        IRoomRoundDAL IRepository.CreateRoomDAL()
        {
            throw new System.NotImplementedException();
        }

        public IUserContainerDAL CreateUserContainerDAL()
        {
            throw new System.NotImplementedException();
        }
    }
}