using InterfaceLayerBD.Room;
using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Room
{
    public class RoomDAL
    {
        public bool Update(IRoomDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Update room SET Name = @Name, Capacity=@Capacity, StakeUpLim=@StakeUpLim, StakeLowLim=@StakeLowLim, RoundTime=@RoundTime WHERE Id = @Id"))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Name);
                        cmd.Parameters.AddWithValue("@Capacity", dto.Capacity);
                        cmd.Parameters.AddWithValue("@StakeUpLim", dto.StakeUpLim);
                        cmd.Parameters.AddWithValue("@StakeLowLim", dto.StakeLowLim);
                        cmd.Parameters.AddWithValue("@RoundTime", dto.RoundTime);
                        cmd.Parameters.AddWithValue("@Id", dto.Id);
                        if (cmd.ExecuteNonQuery() > 0)
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

        public bool Save(IRoomDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO room (Name,Capacity, StakeUpLim,StakeLowLim,RoundTime) VALUES(@Name,@Capacity,@StakeUpLim,@StakeLowLim,@RoundTime)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Name);
                        cmd.Parameters.AddWithValue("@Capacity", dto.Capacity);
                        cmd.Parameters.AddWithValue("@StakeUpLim", dto.StakeUpLim);
                        cmd.Parameters.AddWithValue("@StakeLowLim", dto.StakeLowLim);
                        cmd.Parameters.AddWithValue("@RoundTime", dto.RoundTime);
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

        public bool Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM room WHERE Id=@Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
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

        public List<IRoomDTO> GetAllRooms()
        {
            List<IRoomDTO> dtos = new List<IRoomDTO>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM room"))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                IRoomDTO dto = new RoomDTO()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Capacity = reader.GetInt32(3),
                                    StakeUpLim = reader.GetDouble(4),
                                    StakeLowLim = reader.GetDouble(5),
                                    RoundTime = reader.GetInt32(6)
                                };
                                dtos.Add(dto);
                            }
                        }
                    }
                }
                return dtos;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
