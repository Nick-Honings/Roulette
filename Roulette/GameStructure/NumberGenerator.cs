using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.GameStructure
{
    public class NumberGenerator : IGenerator
    {
        Random rnd;

        public NumberGenerator()
        {
            rnd = new Random();
        }

        public int Generate(int max)
        {
            return rnd.Next(max);
        }
    }
}
