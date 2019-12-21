using InterfaceLayerBD;
using InterfaceLayerBD.Round;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Round
{
    public class RoundDAL: IRoundDAL, IRoundContainerDAL
    {
        private string connString;

        public RoundDAL(string conn)
        {
            connString = conn;
        }

        public bool Update(IRoundDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Update round SET HasEnded = @HasEnded, RoomId=@RoomId WHERE Id = @Id"))
                    {
                        cmd.Parameters.AddWithValue("@HasEnded", dto.HasEnded);
                        cmd.Parameters.AddWithValue("@RoomId", dto.RoomId);
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

        public bool Save(IRoundDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO round (HasEnded, RoomId) VALUES(@HasEnded, @RoomId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@HasEnded", dto.HasEnded);
                        cmd.Parameters.AddWithValue("@RoomId", dto.RoomId);                        
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

        public bool SavePocket(IPocketDTO dto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO result (Id, RoundId, Number, Color) VALUES(@Id, @RoundId, @Number, @Color)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", dto.Id);
                        cmd.Parameters.AddWithValue("@RoomId", dto.RoundId);
                        cmd.Parameters.AddWithValue("@Number", dto.ToNumber);
                        cmd.Parameters.AddWithValue("@Color", dto.ToColorNumber);
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
