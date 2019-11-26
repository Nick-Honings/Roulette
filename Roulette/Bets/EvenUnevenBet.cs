using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class EvenUnevenBet : IBet
    {
        public int ID { get; set; }
        public bool IsEven { get; set; }
        public double Stake { get; set; }
        public int Odd { get; } = 2;

        public EvenUnevenBet(bool isEven)
        {
            IsEven = isEven;
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