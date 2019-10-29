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
        public bool IsEven { get; set; }
        public Result(Color color, int number)
        {
            Color = color;
            Number = number;
            IsEven = IsNumberEven(number);
        }

        private bool IsNumberEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
