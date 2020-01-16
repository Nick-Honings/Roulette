using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.GameStructure
{
    public class Pocket : IPocket, IPocketDTO
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public IPocketNumber Number { get;  }
        public IPocketColor Color { get;  }
        public bool Even { get; }
        
        // Might change this later, seems like repetition.
        public int ToNumber { get; set; }
        public int ToColorNumber { get; set; }

        public Pocket(IPocketNumber number)
        {            
            Number = number;
            Color = CheckColor(number);
            Even = IsNumberEven((int)number);
            ToNumber = (int)Number;
            ToColorNumber = (int)Color;
        }

        private IPocketColor CheckColor(IPocketNumber number)
        {
            if (number == IPocketNumber.Zero)
            {
                return IPocketColor.Green;
            }
            else if ((number > IPocketNumber.Zero && number < IPocketNumber.Eleven) || (number > IPocketNumber.Eightteen && number < IPocketNumber.Twentynine))
            {
                if ((int)number % 2 == 0)
                {
                    return IPocketColor.Black;
                }
                else
                {
                    return IPocketColor.Red;
                }
            }
            else
            {
                if ((int)number % 2 == 0)
                {
                    return IPocketColor.Red;
                }
                else
                {
                    return IPocketColor.Black;
                }
            }
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
