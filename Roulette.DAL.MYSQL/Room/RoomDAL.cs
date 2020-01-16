using InterfaceLayerBD;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.Round;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;

namespace Roulette.DAL.MYSQL.Room
{
    public class RoomDAL : IRoomContainerDAL, IRoomDAL
    {
        private readonly string _connection;

        public RoomDAL(string connection)
        {
            this._connection = connection;
        }

        public bool Update(IRoomDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
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

        public bool AddRoom(IRoomDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
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

        public bool DeleteRoom(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
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
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM room", conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            IRoomDTO dto = new RoomDTO()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Capacity = reader.GetInt32(2),
                                StakeUpLim = reader.GetDouble(3),
                                StakeLowLim = reader.GetDouble(4),
                                RoundTime = reader.GetInt32(5)
                            };
                            dtos.Add(dto);
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

        public bool SaveRound(IRoundDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO room (RoomId, HasEnded) VALUES(@RoomId, @HasEnded)", conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomId", dto.RoomId);
                        cmd.Parameters.AddWithValue("@HasEnded", dto.HasEnded);
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

        public List<IRoundDTO> GetAllRounds(int roomid)
        {
            List<IRoundDTO> dtos = new List<IRoundDTO>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM round WHERE RoomId=@RoomId", conn))
                    {
                        cmd.Parameters.AddWithValue("RoomId", roomid);

                        MySqlDataReader reader = cmd.ExecuteReader();                        
                        while (reader.Read())
                        {
                            IRoundDTO dto = new RoudDTO()
                            {
                                Id = reader.SafeGetInt(0),
                                RoomId = reader.SafeGetInt(1),
                                HasEnded = reader.GetBoolean(2)
                            };
                            dtos.Add(dto);
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

        public List<IUserDTO> GetAllUsers(int roomid)
        {
            List<IUserDTO> dtos = new List<IUserDTO>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE RoomId=@roomid", conn))
                    {
                        cmd.Parameters.AddWithValue("roomid", roomid);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                IUserDTO dto = new UserDTO()
                                {
                                    Id = reader.SafeGetInt(0),
                                    Name = reader.SafeGetString(1),
                                    Email = reader.SafeGetString(3),
                                    Age = reader.SafeGetInt(4),
                                    IsActive = reader.GetBoolean(5),
                                    Balance = reader.SafeGetDecimal(6)
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

        public bool AddUser(int id, int roomid)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET RoomId=@RoomId WHERE Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomId", id);
                        cmd.Parameters.AddWithValue("@Id", roomid);
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

        public bool RemoveUser(int id, int roomid)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("update user set roomid=@roomid where id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@roomid", id);
                        cmd.Parameters.AddWithValue("@id", roomid);
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
    }
}
