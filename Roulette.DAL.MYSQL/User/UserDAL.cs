using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using Roulette.DAL.MYSQL.Admin;

namespace Roulette.DAL.MYSQL
{
    public class UserDAL : IUserContainerDAL, IUserDAL
    {
        private readonly string _connstring;

        public UserDAL(string connstring)
        {
            this._connstring = connstring;
        }

        // Get all users
        // -get full user profile
        // -get bets
        // -get battles

        public bool UpdateProfile(IUserDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Update User SET Name = @Name, Email=@Email, Age=@Age, Active=@Active, Balance=@Balance WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Name);
                        cmd.Parameters.AddWithValue("@Email", dto.Email);
                        cmd.Parameters.AddWithValue("@Age", dto.Age);
                        cmd.Parameters.AddWithValue("@Active", dto.IsActive);
                        cmd.Parameters.AddWithValue("@Balance", dto.Balance);
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

        // Add user
        // -add user profile
        public bool AddUser(IUserDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO User (Name, Password,Email, Age,Active,Balance) VALUES(@Name, @Password,@Email,@Age,@Active,@Balance)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Name);
                        cmd.Parameters.AddWithValue("@Password", dto.Password);
                        cmd.Parameters.AddWithValue("@Email", dto.Email);
                        cmd.Parameters.AddWithValue("@Age", dto.Age);
                        cmd.Parameters.AddWithValue("@Active", dto.IsActive);
                        cmd.Parameters.AddWithValue("@Balance", dto.Balance);
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

        // Delete user
        // -delete user row
        public bool DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM User WHERE Id=@Id", conn))
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

        public List<IUserDTO> GetAllUsers()
        {
            List<IUserDTO> dtos = new List<IUserDTO>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User", conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            IUserDTO dto = new UserDTO()
                            {
                                Id = reader.SafeGetInt(0),
                                Name = reader.SafeGetString(1),
                                Email = reader.SafeGetString(3),
                                Age = reader.SafeGetInt(4),
                                IsActive = reader.GetBoolean(5),
                                Balance = reader.SafeGetDecimal(6),
                                RoomId = reader.SafeGetInt(8)
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

        public IUserDTO GetUserById(int id)
        {
            IUserDTO dto = new UserDTO();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User WHERE Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            dto.Id = id;
                            dto.Name = reader.GetString(1);
                            dto.Email = reader.GetString(3);
                            dto.Age = reader.GetInt32(4);
                            dto.IsActive = reader.GetBoolean(5);
                            dto.Balance = reader.GetDecimal(6);
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

        public int VerifyLogin(string username, string password)
        {
            int id = -1;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User WHERE Name=@Name AND Password=@Password"))
                    {
                        cmd.Parameters.AddWithValue("@Name", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        if(cmd.ExecuteNonQuery() > 0)
                        {
                            MySqlDataReader reader = cmd.ExecuteReader();
                            {
                                while (reader.Read())
                                {
                                    if (reader.GetBoolean(5))
                                    {
                                        id = reader.GetInt32(0);                                        
                                    }                                    
                                }
                            }                           
                        }
                    }
                }
                return id;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool UpdateBalance(int id, decimal balance)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET Balance=@Balance WHERE Id=@Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Balance", balance);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }        
    }
}
