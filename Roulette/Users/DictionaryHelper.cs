using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public static class DictionaryHelper
    {
        public static bool ContainsKeyValue(Dictionary<string, object> dictionary,
                             string expectedKey, object expectedValue)
        {
            
            object actualValue;
            if (!dictionary.TryGetValue(expectedKey, out actualValue))
            {
                return false;
            }
            return actualValue == expectedValue;
        }
    }
}
