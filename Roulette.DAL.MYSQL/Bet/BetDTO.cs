using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Bet
{
    public class BetDTO
    {
        public int Id { get; set; }
        public double Stake { get; set; }
        public double Odd { get; set; }
        //This is the pocketcolor enum
        public int Color { get; set; }
        public int Number { get; set; }
        public bool Even { get; set; }
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }
    }
}
