using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccesFactory.Interfaces
{
    public interface IUserContainerRepository
    {
        IUserContainerDAL CreateUserContainerDAL();
        IUserDAL CreateUserDAL();
        IBetDAL CreateBetDAL();
    }
}
