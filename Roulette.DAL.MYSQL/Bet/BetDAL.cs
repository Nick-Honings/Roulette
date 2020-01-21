using InterfaceLayerBD.Bet;
using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Bet
{
    public class BetDAL : IBetDAL
    {
        private readonly string _connection;

        public BetDAL(string connection)
        {
            this._connection = connection;
        }

        private string SQLStringBuilder(List<string> propNames)
        {
            string sql = "INSERT INTO bet (";
            foreach (var p in propNames)
            {
                sql += p + ",";
            }
            sql = sql.Remove(sql.Length - 1);
            sql += ") VALUES(";
            foreach (var p in propNames)
            {
                sql += $"@{p},";
            }
            sql = sql.Remove(sql.Length - 1);
            sql += ")";

            return sql;
        }

        public bool Save(IBetDTO dto)
        {
            var values = dto.GetBetSpecificInfo();
            List<string> propNames = new List<string>();
            List<object> propValues = new List<object>();
            foreach (var v in values)
            {
                if (v.Key != "Type")
                {
                    propNames.Add(v.Key);
                    propValues.Add(v.Value);
                }
            }

            string sql = SQLStringBuilder(propNames);


            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        for (int i = 0; i < propNames.Count; i++)
                        {
                            string propName = propNames[i];
                            var parameter = cmd.CreateParameter();
                            parameter.ParameterName = "@" + propName;
                            parameter.Value = propValues[i];
                            cmd.Parameters.Add(parameter);
                        }

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IBetDTO GetCurrentBet(int id)
        {
            BetDTO dto = new BetDTO();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM bet WHERE Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            dto.Id = id;
                            dto.Stake = reader.SafeGetDecimal(1);
                            dto.Odd = reader.SafeGetInt(2);
                            dto.Color = reader.SafeGetInt(3);
                            dto.Number = reader.SafeGetInt(4);
                            dto.Even = reader.SafeGetBoolean(5);
                            dto.FirstNumber = reader.SafeGetInt(6);
                            dto.LastNumber = reader.SafeGetInt(7);
                        }
                    }
                }
                return dto;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}