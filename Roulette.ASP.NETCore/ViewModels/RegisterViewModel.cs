using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(60)]
        public string Name { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password)), StringLength(30, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress), Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }

        [Required, Range(18, 120, ErrorMessage = "You have to be over 18 years to register.")]
        public int Age { get; set; }
    }
}
