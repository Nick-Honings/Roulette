using Roulette.ASP.NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.ViewModels
{
    public class UserViewModel
    {
        public List<BetDetailsModel> betDetails { get; set; }
        public List<UserDetailsModel> detailsModel { get; set; }
    }
}
