﻿using InterfaceLayerBD;
using InterfaceLayerBD.Bet;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory.TestDAL
{
    public class TestUserDAL : IUserDAL
    {
        public bool Insert<T>(object[] param)
        {
            return true;
        }

        public bool Save(IBetDTO dto)
        {
            return true;
        }

        public bool Update(IUserDTO dto)
        {
            return true;
        }
    }
}
