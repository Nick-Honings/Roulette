using InterfaceLayerBD;
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
        public PocketNumber Number { get; }
        public PocketColor Color { get; }
        public bool Even { get; }
        
        // Might change this later, seems like repetition.
        public int ToNumber { get; }
        public int ToColorNumber { get; }

        public Pocket(PocketNumber number)
        {            
            Number = number;
            Color = CheckColor(number);
            Even = IsNumberEven((int)number);
            ToNumber = (int)Number;
            ToColorNumber = (int)Color;
        }

        private PocketColor CheckColor(PocketNumber number)
        {
            if (number == PocketNumber.Zero)
            {
                return PocketColor.Green;
            }
            else if ((number > PocketNumber.Zero && number < PocketNumber.Eleven) || (number > PocketNumber.Eightteen && number < PocketNumber.Twentynine))
            {
                if ((int)number % 2 == 0)
                {
                    return PocketColor.Black;
                }
                else
                {
                    return PocketColor.Red;
                }
            }
            else
            {
                if ((int)number % 2 == 0)
                {
                    return PocketColor.Red;
                }
                else
                {
                    return PocketColor.Black;
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
