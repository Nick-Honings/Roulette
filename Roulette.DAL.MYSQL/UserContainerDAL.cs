using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD;

namespace Roulette.DAL.MYSQL
{
    public class UserContainerDAL : IUserContainerDAL, IUserDAL
    {
        // Get all users
        // -get full user profile
        // -get bets
        // -get battles

        public bool Update(IUserDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Update User SET Name = @Name, Email=@Email, Age=@Age, Active=@IsActive, Balance=@Balance WHERE Id = @Id"))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Name);
                        cmd.Parameters.AddWithValue("@Email", dto.Email);
                        cmd.Parameters.AddWithValue("@Age", dto.Age);
                        cmd.Parameters.AddWithValue("@IsActive", dto.IsActive);
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
        public bool Save(IUserDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO User (Name, Password,Email, Age,IsActive,Balance) VALUES(@Name, @Password,@Email,@Age,@IsActive,@Balance)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Name);
                        cmd.Parameters.AddWithValue("@Password", dto.Password);
                        cmd.Parameters.AddWithValue("@Emai", dto.Email);
                        cmd.Parameters.AddWithValue("@Age", dto.Age);
                        cmd.Parameters.AddWithValue("@IsActive", dto.IsActive);
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
        public bool Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM User WHERE Id=@Id"))
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
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User"))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                IUserDTO dto = new UserDTO()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Email = reader.GetString(3),
                                    Age = reader.GetInt32(4),
                                    IsActive = reader.GetBoolean(5),
                                    Balance = reader.GetDouble(6)

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

        public IUserDTO GetUserById(int id)
        {
            IUserDTO dto = new UserDTO();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionHelper.CnnVal("DemoDB")))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT FROM User WHERE Id=@Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                dto.Id = id;
                                dto.Name = reader.GetString(1);
                                dto.Email = reader.GetString(3);
                                dto.Age = reader.GetInt32(4);
                                dto.IsActive = reader.GetBoolean(5);
                                dto.Balance = reader.GetDouble(6);
                            }
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




        // Get User By Id


    }
}
