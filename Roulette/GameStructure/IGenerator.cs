using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.GameStructure
{
    public interface IGenerator
    {
        int Generate(int max);
    }
}
