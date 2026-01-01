using System.Data;
using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryAPI.DAL
{
    public class DeliveryDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<dto_Delivery> GetAllDeliveries()
        {
            var list = new List<dto_Delivery>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Deliveries";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new dto_Delivery
                    {
                        IdDelivery = (int)reader["IdDelivery"],
                        IdOrder = (int)reader["IdOrder"],
                        IdShipper = (int)reader["IdShipper"],
                        ThoiGianNhanHang = reader["ThoiGianNhanHang"] == DBNull.Value ? null : (DateTime?)reader["ThoiGianNhanHang"],
                        ThoiGianDuKien = reader["ThoiGianDuKien"] == DBNull.Value ? null : (DateTime?)reader["ThoiGianDuKien"],
                        TrangThai = reader["TrangThai"].ToString()
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool CreateDelivery(dto_Delivery delivery)
        {
            string query = @"INSERT INTO Deliveries
                            (IdOrder, IdShipper, ThoiGianNhanHang, ThoiGianDuKien, TrangThai)
                            VALUES (@IdOrder, @IdShipper, @ThoiGianNhanHang, @ThoiGianDuKien, @TrangThai)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrder", delivery.IdOrder);
                cmd.Parameters.AddWithValue("@IdShipper", delivery.IdShipper);
                cmd.Parameters.AddWithValue("@ThoiGianNhanHang", (object?)delivery.ThoiGianNhanHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ThoiGianDuKien", (object?)delivery.ThoiGianDuKien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", delivery.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool UpdateDelivery(dto_Delivery delivery)
        {
            string query = @"UPDATE Deliveries SET
                            IdOrder = @IdOrder,
                            IdShipper = @IdShipper,
                            ThoiGianNhanHang = @ThoiGianNhanHang,
                            ThoiGianDuKien = @ThoiGianDuKien,
                            TrangThai = @TrangThai
                            WHERE IdDelivery = @IdDelivery";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdDelivery", delivery.IdDelivery);
                cmd.Parameters.AddWithValue("@IdOrder", delivery.IdOrder);
                cmd.Parameters.AddWithValue("@IdShipper", delivery.IdShipper);
                cmd.Parameters.AddWithValue("@ThoiGianNhanHang", (object?)delivery.ThoiGianNhanHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ThoiGianDuKien", (object?)delivery.ThoiGianDuKien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", delivery.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool DeleteDelivery(int id)
        {
            string query = "DELETE FROM Deliveries WHERE IdDelivery = @Id";

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
