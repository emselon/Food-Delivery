using System.Data;
using Microsoft.Data.SqlClient;
using Giao_đồ_ăn.DTO;
using System.Collections.Generic;

namespace FoodDeliveryAPI.DAL
{
    public class LoaiTaiKhoanDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<LoaiTaiKhoanDTO> GetAll()
        {
            var list = new List<LoaiTaiKhoanDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LoaiTaiKhoan";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new LoaiTaiKhoanDTO
                    {
                        IdLoaiTaiKhoan = (int)reader["IdLoaiTaiKhoan"],
                        TenLoaiTaiKhoan = reader["TenLoaiTaiKhoan"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        TrangThai = (bool)reader["TrangThai"],
                        NgayTao = (DateTime)reader["NgayTao"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool Create(LoaiTaiKhoanDTO loai)
        {
            string query = @"INSERT INTO LoaiTaiKhoan (TenLoaiTaiKhoan, MoTa, TrangThai)
                             VALUES (@TenLoaiTaiKhoan, @MoTa, @TrangThai)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenLoaiTaiKhoan", loai.TenLoaiTaiKhoan);
                cmd.Parameters.AddWithValue("@MoTa", loai.MoTa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", loai.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool Update(LoaiTaiKhoanDTO loai)
        {
            string query = @"UPDATE LoaiTaiKhoan
                             SET TenLoaiTaiKhoan=@TenLoaiTaiKhoan,
                                 MoTa=@MoTa,
                                 TrangThai=@TrangThai
                             WHERE IdLoaiTaiKhoan=@IdLoaiTaiKhoan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdLoaiTaiKhoan", loai.IdLoaiTaiKhoan);
                cmd.Parameters.AddWithValue("@TenLoaiTaiKhoan", loai.TenLoaiTaiKhoan);
                cmd.Parameters.AddWithValue("@MoTa", loai.MoTa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", loai.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool Delete(int id)
        {
            string query = @"DELETE FROM LoaiTaiKhoan WHERE IdLoaiTaiKhoan=@Id";
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
