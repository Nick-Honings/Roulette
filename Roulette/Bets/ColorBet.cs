using InterfaceLayerBD.Bet;
using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class ColorBet : IBet
    {
        // Use
        public int ID { get; set; }
        public PocketColor Color { get; private set; }     
        public double Stake { get; set; }
        public int Odd { get; private set; } = 2;

        private IBetDAL betDAL;

        public ColorBet(PocketColor color, IBetDAL dAL)
        {
            Color = color;
            betDAL = dAL;
        }
        public double GetReturnStake()
        {
            return Stake * Odd;
        }


        public Dictionary<string, object> GetInfo()
        {
            Dictionary<string, object> propValue = new Dictionary<string, object>();
            var properties = this.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                propValue.Add(prop.Name, prop.GetValue(this, null));
            }
            return propValue;
        }
    }
}
