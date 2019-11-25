using InterfaceLayerBD;
using Roulette.DAL.MYSQL;
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
    }
}
