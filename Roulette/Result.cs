using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Result
    {
        public Color Color { get; set; }
        public int Number { get; set; }

        public Result(Color color, int number)
        {
            Color = color;
            Number = number;
        }
    }
}
