using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccesFactory.Interfaces
{
    public interface IBetRepository
    {
        IBetDAL CreateBetDAL();
    }
}
