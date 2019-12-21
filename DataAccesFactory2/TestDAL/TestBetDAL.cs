using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory2.TestDAL
{
    public class TestBetDAL
    {
        public bool Insert<T>(object[] param)
        {
            return true;
        }

        public bool Save(IBetDTO dto)
        {
            return true;
        }
    }
}
