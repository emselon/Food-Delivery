using System.Data;
using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryAPI.DAL
{
    public class MenuItemDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<dto_MenuItem> GetAllMenuItems()
        {
            var list = new List<dto_MenuItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuItem";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new dto_MenuItem
                    {
                        IdMenuItem = (int)reader["IdMenuItem"],
                        IdRestaurant = (int)reader["IdRestaurant"],
                        TenMon = reader["TenMon"].ToString(),
                        Gia = (decimal)reader["Gia"],
                        TrangThai = (bool)reader["TrangThai"],
                        NgayTao = (DateTime)reader["NgayTao"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool CreateMenuItem(dto_MenuItem item)
        {
            string query = @"INSERT INTO MenuItem
                            (IdRestaurant, TenMon, Gia, TrangThai)
                            VALUES (@IdRestaurant, @TenMon, @Gia, @TrangThai)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdRestaurant", item.IdRestaurant);
                cmd.Parameters.AddWithValue("@TenMon", item.TenMon);
                cmd.Parameters.AddWithValue("@Gia", item.Gia);
                cmd.Parameters.AddWithValue("@TrangThai", item.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool UpdateMenuItem(dto_MenuItem item)
        {
            string query = @"UPDATE MenuItem 
                             SET IdRestaurant=@IdRestaurant,
                                 TenMon=@TenMon,
                                 Gia=@Gia,
                                 TrangThai=@TrangThai
                             WHERE IdMenuItem=@IdMenuItem";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdMenuItem", item.IdMenuItem);
                cmd.Parameters.AddWithValue("@IdRestaurant", item.IdRestaurant);
                cmd.Parameters.AddWithValue("@TenMon", item.TenMon);
                cmd.Parameters.AddWithValue("@Gia", item.Gia);
                cmd.Parameters.AddWithValue("@TrangThai", item.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool DeleteMenuItem(int id)
        {
            string query = "DELETE FROM MenuItem WHERE IdMenuItem = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
