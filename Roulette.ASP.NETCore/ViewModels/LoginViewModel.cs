using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required, StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
