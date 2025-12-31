using DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Giao_đồ_ăn.Models;

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


    }
}

