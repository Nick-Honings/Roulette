using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.Models
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
    }
}
