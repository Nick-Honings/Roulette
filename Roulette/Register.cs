﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Register
    {
        public static User RegisterUser(string name, string password,string email, int age)
        {
            return new User()
            {
                Name = name,
                Password = password,
                Email = email,
                Age = age
            };
        }
    }
}
