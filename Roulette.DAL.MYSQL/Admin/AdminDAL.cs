using InterfaceLayerBD;
using InterfaceLayerBD.Admin;
using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Admin
{
    public class AdminDAL: IAdminDAL, IAdminContainerDAL
    {
        private readonly string _connection;

        public AdminDAL(string connection)
        {
            this._connection = connection;
        }

        public List<IAdminDTO> GetAllAdmins()
        {
            List<IAdminDTO> dtos = new List<IAdminDTO>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User"))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        {
                            while (reader.Read())
                            {
                                AdminDTO dto = new AdminDTO()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Permissions = reader.GetString(2).Split(',').ToList(),
                                    UserRole = reader.GetInt32(3)

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

        public int VerifyLogin(string username, string password)
        {
            int id = -1;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User WHERE Name=@Name AND Password=@Password"))
                    {
                        cmd.Parameters.AddWithValue("@Name", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        if (cmd.ExecuteNonQuery() > 0)
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
                using (MySqlConnection conn = new MySqlConnection(_connection))
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

        public bool DisableUser(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET Active=@Active WHERE Id=@Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Active", false);

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

        public bool SetUserBalance(int id, decimal balance)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET Balance=@Balance WHERE Id=@Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Balance", false);

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

        public bool EnableUser(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET Active=@Active WHERE Id=@Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Active", true);

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

        public bool AddUser(IUserDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
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
        public bool DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
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

        public DataSet GetUserAndBetDetails()
        {
            DataSet output = new DataSet();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT " +
                                                                        "u.Id, u.Name, u.Email, u.Password, u.Age, u.Active, u.Balance, " +
                                                                        "b.Stake, b.Odd, b.Color, b.Number, b.Even, b.FirstNumber, b.SecondNumber " +
                                                                        "FROM user AS u " +
                                                                        "INNER JOIN " +
                                                                        "bet as b on u.BetId = b.Id ORDER BY u.Id", conn))
                        {
                            da.Fill(output, "UserBetDetails");


                            return output;
                        }
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
