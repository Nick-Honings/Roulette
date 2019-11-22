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
    public class BetDAL<T>
    {
        
        public bool Save(IBetDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO bet (Stake, Odd, Color, Number,Even,FirstNumber,SecondNumber) VALUES(@Stake, @Odd, @Color, @Number,@Even,@FirstNumber,@SecondNumber)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Stake", dto.Stake);
                        cmd.Parameters.AddWithValue("@Odd", dto.Odd);
                        cmd.Parameters.AddWithValue("@Color", dto.Color);
                        cmd.Parameters.AddWithValue("@Number", dto.Number);
                        cmd.Parameters.AddWithValue("@Even", dto.Even);
                        cmd.Parameters.AddWithValue("@FirstNumber", dto.FirstNumber);
                        cmd.Parameters.AddWithValue("@SecondNumber", dto.LastNumber);
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

        private List<PropertyInfo> getUnderLyingProperties()
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();

            if(typeof(T).Equals(typeof(IColorBetDTO)))
            {
                BetDTO dto = new BetDTO();
                properties = dto.GetType().GetProperties().ToList();
            }
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

        public void Insert(object[] param)
        {
            string sql = "INSERT INTO bet (Stake,Odd,Color,Number,Even,FirstNumber,SecondNumber) VALUES(@Stake,@Odd,@Color,@Number,@Even,@FirstNumber,@SecondNumber)";
            var properties = getUnderLyingProperties();
            properties = RemoveUnusedProps(sql, properties);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
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
                        cmd.ExecuteNonQuery();
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
