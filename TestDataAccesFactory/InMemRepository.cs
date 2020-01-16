using TestDataAccesFactory.TestDAL;
using InterfaceLayerBD;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD.Bet;
using DataAccesFactory.Factory;
using TestDataAccesFactory.Interfaces;
using InterfaceLayerBD.Admin;
using InterfaceLayerBD.Round;

namespace TestDataAccesFactory
{
    public class InMemRepository : IRepository, IBetRepository, IUserContainerRepository, IRoomContainerRepository, IAdminRepository, INewsItemRepository
    {
        public IUserDAL CreateUserDAL()
        {
            return new TestUserDAL();
        }

        public IUserContainerDAL CreateUserContainerDAL()
        {
            return new TestUserContainerDAL();
        }

        public IRoomDAL CreateRoomDAL()
        {
            return new TestRoomDAL();
        }

        public IRoundDAL CreateRoundDAL()
        {
            return new TestRoundDAL();
        }

        public IRoomContainerDAL CreateRoomContainerDAL()
        {
            return new TestRoomContainerDAL();
        }

        public INewsItemContainerDAL CreateNewsItemContainerDAL()
        {
            return new TestNewsItemContainerDAL();
        }

        public INewsItemDAL CreateNewsItemDAL()
        {
            return new TestNewsItemDAL();
        }

        public IBetDAL CreateBetDAL()
        {
            return new TestBetDAL();
        }

        public IAdminContainerDAL CreateAdminContainerDAL()
        {
            return new TestAdminContainerDAL();
        }

        public IAdminDAL CreateAdminDAL()
        {
            return new TestAdminDAL();
        }
    }
}
