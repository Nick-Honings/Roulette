﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD.Room
{
    public interface IRoomDAL
    {
        bool Update(IRoomDTO dto);
    }
}
