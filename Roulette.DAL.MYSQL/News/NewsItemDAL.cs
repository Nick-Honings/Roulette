using InterfaceLayerBD.News;
using MySql.Data.MySqlClient;
using Roulette.DAL.MYSQL.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.News
{
    public class NewsItemDAL : INewsItemDAL, INewsItemContainerDAL
    {
        private readonly string _connection;

        public NewsItemDAL(string connection)
        {
            this._connection = connection;
        }
        public bool Update(INewsItemDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Update newsitem SET Title = @Title, Description=@Description, Date=@Date WHERE Id = @Id"))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.Title);
                        cmd.Parameters.AddWithValue("@Email", dto.Description);
                        cmd.Parameters.AddWithValue("@Age", dto.date);
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

        public bool Save(INewsItemDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO newsitem (Title, Description,Date) VALUES(@Title, @Description,@Date)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", dto.Title);
                        cmd.Parameters.AddWithValue("@Description", dto.Description);
                        cmd.Parameters.AddWithValue("@Date", dto.date);
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
                using (MySqlConnection conn = new MySqlConnection(_connection))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM newsitem WHERE Id=@Id"))
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

        public List<INewsItemDTO> GetAllNewsItems()
        {
            List<INewsItemDTO> dtos = new List<INewsItemDTO>();
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
                                INewsItemDTO dto = new NewsItemDTO()
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Description = reader.GetString(3),
                                    date = reader.GetDateTime(4),
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
