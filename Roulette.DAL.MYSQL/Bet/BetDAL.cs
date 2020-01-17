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
    public class BetDAL: IBetDAL
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
            sql = sql.Remove(sql.Length-1);
            sql += ") VALUES(";
            foreach (var p in propNames)
            {
                sql += $"@{p},"; 
            }
            sql = sql.Remove(sql.Length-1);
            sql += ")";

            return sql;
        }
        
        public bool Save(IBetDTO dto)
        {
            //string sql = "INSERT INTO bet (Stake,Odd,Color,Number,Even,FirstNumber,SecondNumber) VALUES(@Stake,@Odd,@Color,@Number,@Even,@FirstNumber,@SecondNumber)";
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

        //private List<PropertyInfo> getUnderLyingProperties()
        //{
        //    List<PropertyInfo> properties = new List<PropertyInfo>();

        //    if(typeof(T).Equals(typeof(IColorBetDTO)))
        //    {
        //        BetDTO dto = new BetDTO();
        //        properties = dto.GetType().GetProperties().ToList();
        //    }
        //    return properties;
        //}

        private List<PropertyInfo> getUnderLyingProperties<T>()
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();

            //if (typeof(T).Equals(typeof(IColorBetDTO)))
            //{
            //    BetDTO dto = new BetDTO();
            //    properties = dto.GetType().GetProperties().ToList();
            //}
            return properties;
        }

        private List<PropertyInfo> RemoveUnusedProps(string sql, List<PropertyInfo> properties)
        {
            for (int i = properties.Count; i >= 0; i--)
            {
                if(!sql.Contains(properties[i].Name))
                {
                    properties.RemoveAt(i);
                }
            }
            return properties;
        }

        public bool Insert<T>(object[] param)
        {
            string sql = "INSERT INTO bet (Stake,Odd,Color,Number,Even,FirstNumber,SecondNumber) VALUES(@Stake,@Odd,@Color,@Number,@Even,@FirstNumber,@SecondNumber)";
            
            var properties = getUnderLyingProperties<T>();
            properties = RemoveUnusedProps(sql, properties);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        for (int i = 0; i < properties.Count; i++)
                        {
                            string propName = properties[i].Name;
                            var parameter = cmd.CreateParameter();
                            parameter.ParameterName = "@" + propName;
                            parameter.Value = param[i];
                            cmd.Parameters.Add(parameter);
                        }
                        if(cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);                
            }
        }
    }


}
