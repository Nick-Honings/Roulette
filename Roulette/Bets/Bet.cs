using InterfaceLayerBD.Bet;
using System.Collections.Generic;
using System.Reflection;

namespace Roulette.Bets
{
    public class Bet : IBet, IBetDTO
    {
        public int Id { get; set; }        
        public decimal Stake { get; set; }
        public double Odd { get; set; }
        public BetType Type { get; set; }

        public decimal GetReturnStake()
        {
            return Stake * (decimal)Odd;
        }

        public Dictionary<string, object> GetBetSpecificInfo()
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
