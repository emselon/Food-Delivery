using System.Data;
using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryAPI.DAL
{
    public class UserDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<dto_User> GetAllUsers()
        {
            var list = new List<dto_User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UserInfo";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new dto_User
                    {
                        IdUser = (int)reader["IdUser"],
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        TrangThai = (bool)reader["TrangThai"],
                        NgayTao = (DateTime)reader["NgayTao"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool CreateUser(dto_User user)
        {
            string query = @"INSERT INTO UserInfo
                (HoTen, SoDienThoai, Email, DiaChi, TrangThai)
                VALUES (@HoTen, @SoDienThoai, @Email, @DiaChi, @TrangThai)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", user.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", user.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DiaChi", user.DiaChi);
                cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool UpdateUser(dto_User user)
        {
            string query = @"UPDATE UserInfo 
                             SET HoTen=@HoTen, SoDienThoai=@SoDienThoai,
                                 Email=@Email, DiaChi=@DiaChi, TrangThai=@TrangThai
                             WHERE IdUser=@IdUser";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", user.IdUser);
                cmd.Parameters.AddWithValue("@HoTen", user.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", user.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DiaChi", user.DiaChi);
                cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool DeleteUser(int id)
        {
            string query = "DELETE FROM UserInfo WHERE IdUser = @IdUser";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
