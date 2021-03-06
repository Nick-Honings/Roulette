﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD
{
    public interface IUserDTO
    {
        int Id { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        int Age { get; set; }
        bool IsActive { get; set; }
        decimal Balance { get; set; }
        List<string> Permissions { get; }
        int UserRole { get; }
        int RoomId { get; set; }
    }
}
