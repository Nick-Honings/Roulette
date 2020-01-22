using Roulette.ASP.NET.Models;
using Roulette.ASP.NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.ViewModels
{
    public class BetViewModel
    {
        public List<SingleNumberBetModel> SingleBets { get; set; }
        public List<ColorBetModel> ColorBets { get; set; }
        public List<NeighboursBetModel> NeighboursBets { get; set; }
        public List<EvenUnevenBetModel> EvenUnevenBets { get; set; }

        public BetViewModel()
        {
            SingleBets = new List<SingleNumberBetModel>();
            ColorBets = new List<ColorBetModel>();
            NeighboursBets = new List<NeighboursBetModel>();
            EvenUnevenBets = new List<EvenUnevenBetModel>();
        }

    }
}
