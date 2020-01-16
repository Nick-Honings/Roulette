using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.Models
{
    public class BetDetailsModel
    {
        public int Id { get; set; }
        public decimal Stake { get; set; }
        public double Odd { get; set; }
        public int Color { get; set; }
        public int Number { get; set; }
        public bool Even { get; set; }
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }
    }
}
