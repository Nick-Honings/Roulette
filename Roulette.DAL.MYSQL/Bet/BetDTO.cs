using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Bet
{
    public class BetDTO : IBetDTO
    {
        public int Id { get; set; }
        public decimal Stake { get; set; }
        public double Odd { get; set; }
        //This is the pocketcolor enum
        public int Color { get; set; }
        public int Number { get; set; }
        public bool Even { get; set; }
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }

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
