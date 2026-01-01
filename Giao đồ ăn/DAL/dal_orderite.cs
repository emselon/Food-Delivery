using System.Data;
using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryAPI.DAL
{
    public class OrderItemDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<dto_OrderItem> GetAllOrderItems()
        {
            var list = new List<dto_OrderItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrderItems";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new dto_OrderItem
                    {
                        IdOrderItem = (int)reader["IdOrderItem"],
                        IdOrder = (int)reader["IdOrder"],
                        IdMenuItem = (int)reader["IdMenuItem"],
                        SoLuong = (int)reader["SoLuong"],
                        DonGia = (decimal)reader["DonGia"],
                        ThanhTien = (decimal)reader["ThanhTien"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool CreateOrderItem(dto_OrderItem item)
        {
            string query = @"INSERT INTO OrderItems
                            (IdOrder, IdMenuItem, SoLuong, DonGia, ThanhTien)
                            VALUES (@IdOrder, @IdMenuItem, @SoLuong, @DonGia, @ThanhTien)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrder", item.IdOrder);
                cmd.Parameters.AddWithValue("@IdMenuItem", item.IdMenuItem);
                cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", item.DonGia);
                cmd.Parameters.AddWithValue("@ThanhTien", item.ThanhTien);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool UpdateOrderItem(dto_OrderItem item)
        {
            string query = @"UPDATE OrderItems 
                             SET IdOrder=@IdOrder,
                                 IdMenuItem=@IdMenuItem,
                                 SoLuong=@SoLuong,
                                 DonGia=@DonGia,
                                 ThanhTien=@ThanhTien
                             WHERE IdOrderItem=@IdOrderItem";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrderItem", item.IdOrderItem);
                cmd.Parameters.AddWithValue("@IdOrder", item.IdOrder);
                cmd.Parameters.AddWithValue("@IdMenuItem", item.IdMenuItem);
                cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", item.DonGia);
                cmd.Parameters.AddWithValue("@ThanhTien", item.ThanhTien);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool DeleteOrderItem(int id)
        {
            string query = "DELETE FROM OrderItems WHERE IdOrderItem = @Id";

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
