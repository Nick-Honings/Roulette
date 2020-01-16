using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.GameStructure
{
    public class Wheel : IWheel
    {
        private IGenerator generator;

        public Wheel(IGenerator generator)
        {
            this.generator = generator;
        }

        public IPocket Spin()
        {
            int number = generator.Generate(36);
            return new Pocket((IPocketNumber)number);
        }
    }
}
