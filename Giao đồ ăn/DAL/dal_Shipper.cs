using DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Giao_đồ_ăn.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DAL
{
    public class ShipperDAL
    {
        // Chuỗi kết nối SQL Server
        private readonly string connectionString = @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // Lấy tất cả Shipper
        public List<dto_Shipper> GetAllShippers()
        {
            var list = new List<dto_Shipper>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Shipper";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var shipperDto = new dto_Shipper
                    {
                        IdShipper = (int)reader["IdShipper"],
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        BienSoXe = reader["BienSoXe"].ToString(),
                        TrangThai = (bool)reader["TrangThai"],
                        NgayTao = (DateTime)reader["NgayTao"]
                    };
                    list.Add(shipperDto); // thêm đúng object dto_Shipper
                }
            }
            return list;
        }
        public bool CreateShipper(dto_Shipper shipper)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Shipper 
                        (HoTen, SoDienThoai, BienSoXe, TrangThai)
                        VALUES (@HoTen, @SoDienThoai, @BienSoXe, @TrangThai)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", shipper.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", shipper.SoDienThoai);
                cmd.Parameters.AddWithValue("@BienSoXe", shipper.BienSoXe);
                cmd.Parameters.AddWithValue("@TrangThai", shipper.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DeleteShipper(int idShipper)
        {
            string query = "DELETE FROM Shipper WHERE IdShipper = @IdShipper";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdShipper", idShipper);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }
        public bool UpdateShipper(dto_Shipper shipper)
        {
            string sql = @"UPDATE Shipper 
                           SET HoTen = @HoTen,
                               SoDienThoai = @SoDienThoai,
                               BienSoXe = @BienSoXe,
                               TrangThai = @TrangThai
                           WHERE IdShipper = @IdShipper";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdShipper", shipper.IdShipper);
                cmd.Parameters.AddWithValue("@HoTen", shipper.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", shipper.SoDienThoai);
                cmd.Parameters.AddWithValue("@BienSoXe", shipper.BienSoXe);
                cmd.Parameters.AddWithValue("@TrangThai", shipper.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }


    }
}

