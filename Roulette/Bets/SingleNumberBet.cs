using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class SingleNumberBet : IBet
    {
        // Use
        public int ID { get; set; }
        public PocketNumber PocketNumber { get; private set; }
        public double Stake { get; set; }
        public int Odd { get; } = 35;


        public SingleNumberBet(PocketNumber number)
        {
            PocketNumber = number;
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
