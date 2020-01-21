using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.utils
{
    public static class CheckForDBNull
    {
        public static string SafeGetString(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public static int SafeGetInt(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return -1;
        }

        public static decimal SafeGetDecimal(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDecimal(colIndex);
            return -1;
        }

        public static bool SafeGetBoolean(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetBoolean(colIndex);
            return false;
        }
    }
}
