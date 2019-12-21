using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class Bet
    {
        public int ID { get; set; }
        public decimal Stake { get; set; }
        public double Odd { get; set; }

        public decimal GetReturnStake()
        {
            return Stake * (decimal)Odd;
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
