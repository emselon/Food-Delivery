using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FoodDeliveryAPI.DAL
{
    public class RestaurantDAL
    {
        // Chuỗi kết nối SQL Server
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // ===================== GET ALL =====================
        public List<dto_restaurant> GetAllRestaurants()
        {
            var list = new List<dto_restaurant>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Restaurant";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var restaurant = new dto_restaurant
                    {
                        IdRestaurant = (int)reader["IdRestaurant"],
                        TenRestaurant = reader["TenRestaurant"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        TrangThai = (bool)reader["TrangThai"],
                        NgayTao = (DateTime)reader["NgayTao"]
                    };

                    list.Add(restaurant);
                }
            }
            return list;
        }

        // ===================== CREATE =====================
        public bool CreateRestaurant(dto_restaurant restaurant)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Restaurant
                                (TenRestaurant, DiaChi, SoDienThoai, TrangThai)
                                VALUES (@TenRestaurant, @DiaChi, @SoDienThoai, @TrangThai)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenRestaurant", restaurant.TenRestaurant);
                cmd.Parameters.AddWithValue("@DiaChi", restaurant.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", restaurant.SoDienThoai);
                cmd.Parameters.AddWithValue("@TrangThai", restaurant.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ===================== UPDATE =====================
        public bool UpdateRestaurant(dto_restaurant restaurant)
        {
            string query = @"UPDATE Restaurant 
                             SET TenRestaurant = @TenRestaurant,
                                 DiaChi = @DiaChi,
                                 SoDienThoai = @SoDienThoai,
                                 TrangThai = @TrangThai
                             WHERE IdRestaurant = @IdRestaurant";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdRestaurant", restaurant.IdRestaurant);
                cmd.Parameters.AddWithValue("@TenRestaurant", restaurant.TenRestaurant);
                cmd.Parameters.AddWithValue("@DiaChi", restaurant.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", restaurant.SoDienThoai);
                cmd.Parameters.AddWithValue("@TrangThai", restaurant.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ===================== DELETE =====================
        public bool DeleteRestaurant(int idRestaurant)
        {
            string query = "DELETE FROM Restaurant WHERE IdRestaurant = @IdRestaurant";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdRestaurant", idRestaurant);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
