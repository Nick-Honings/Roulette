using DataAccesFactory.TestDAL;
using InterfaceLayerBD;
using InterfaceLayerBD.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory
{
    public static class TestFactory
    {
        public static IUserDAL CreateTestUserDAL()
        {
            return new TestUserDAL();
        }

        public static IUserContainerDAL CreateTestUserContainerDAL()
        {
            return new TestUserContainerDAL();
        }

        public static IRoomDAL CreateTestRoomDAL()
        {
            return new TestRoomDAL();
        }

        public static IRoomContainerDAL CreateTestRoomContainerDAL()
        {
            return new TestRoomContainerDAL();
        }
    }
}
