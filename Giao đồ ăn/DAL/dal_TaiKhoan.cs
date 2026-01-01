using System.Data;
using Microsoft.Data.SqlClient;
using Giao_đồ_ăn.DTO;
using System.Collections.Generic;

namespace FoodDeliveryAPI.DAL
{
    public class TaiKhoanDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<TaiKhoanDTO> GetAll()
        {
            var list = new List<TaiKhoanDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TaiKhoan";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new TaiKhoanDTO
                    {
                        IdTaiKhoan = (int)reader["IdTaiKhoan"],
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        IdLoaiTaiKhoan = (int)reader["IdLoaiTaiKhoan"],
                        IdUser = reader["IdUser"] != DBNull.Value ? (int?)reader["IdUser"] : null,
                        IdShipper = reader["IdShipper"] != DBNull.Value ? (int?)reader["IdShipper"] : null,
                        IdRestaurant = reader["IdRestaurant"] != DBNull.Value ? (int?)reader["IdRestaurant"] : null,
                        TrangThai = (bool)reader["TrangThai"],
                        NgayTao = (DateTime)reader["NgayTao"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool Create(TaiKhoanDTO tk)
        {
            string query = @"INSERT INTO TaiKhoan 
                             (TenDangNhap, MatKhau, IdLoaiTaiKhoan, IdUser, IdShipper, IdRestaurant, TrangThai)
                             VALUES (@TenDangNhap, @MatKhau, @IdLoaiTaiKhoan, @IdUser, @IdShipper, @IdRestaurant, @TrangThai)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau); // Hash nếu cần
                cmd.Parameters.AddWithValue("@IdLoaiTaiKhoan", tk.IdLoaiTaiKhoan);
                cmd.Parameters.AddWithValue("@IdUser", tk.IdUser ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdShipper", tk.IdShipper ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdRestaurant", tk.IdRestaurant ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool Update(TaiKhoanDTO tk)
        {
            string query = @"UPDATE TaiKhoan
                             SET TenDangNhap=@TenDangNhap,
                                 MatKhau=@MatKhau,
                                 IdLoaiTaiKhoan=@IdLoaiTaiKhoan,
                                 IdUser=@IdUser,
                                 IdShipper=@IdShipper,
                                 IdRestaurant=@IdRestaurant,
                                 TrangThai=@TrangThai
                             WHERE IdTaiKhoan=@IdTaiKhoan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdTaiKhoan", tk.IdTaiKhoan);
                cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                cmd.Parameters.AddWithValue("@IdLoaiTaiKhoan", tk.IdLoaiTaiKhoan);
                cmd.Parameters.AddWithValue("@IdUser", tk.IdUser ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdShipper", tk.IdShipper ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdRestaurant", tk.IdRestaurant ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool Delete(int id)
        {
            string query = @"DELETE FROM TaiKhoan WHERE IdTaiKhoan=@Id";
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
