using System.Data;
using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryAPI.DAL
{
    public class OrderDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<dto_Order> GetAllOrders()
        {
            var list = new List<dto_Order>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new dto_Order
                    {
                        IdOrder = (int)reader["IdOrder"],
                        IdUser = (int)reader["IdUser"],
                        IdRestaurant = (int)reader["IdRestaurant"],
                        TongTien = (decimal)reader["TongTien"],
                        PhiVanChuyen = (decimal)reader["PhiVanChuyen"],
                        TrangThai = reader["TrangThai"].ToString(),
                        DiaChiGiao = reader["DiaChiGiao"].ToString(),
                        NgayDat = (DateTime)reader["NgayDat"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool CreateOrder(dto_Order order)
        {
            string query = @"INSERT INTO Orders
                            (IdUser, IdRestaurant, TongTien, PhiVanChuyen, TrangThai, DiaChiGiao)
                            VALUES (@IdUser, @IdRestaurant, @TongTien, @PhiVanChuyen, @TrangThai, @DiaChiGiao)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", order.IdUser);
                cmd.Parameters.AddWithValue("@IdRestaurant", order.IdRestaurant);
                cmd.Parameters.AddWithValue("@TongTien", order.TongTien);
                cmd.Parameters.AddWithValue("@PhiVanChuyen", order.PhiVanChuyen);
                cmd.Parameters.AddWithValue("@TrangThai", order.TrangThai);
                cmd.Parameters.AddWithValue("@DiaChiGiao", order.DiaChiGiao);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool UpdateOrder(dto_Order order)
        {
            string query = @"UPDATE Orders SET
                            IdUser=@IdUser,
                            IdRestaurant=@IdRestaurant,
                            TongTien=@TongTien,
                            PhiVanChuyen=@PhiVanChuyen,
                            TrangThai=@TrangThai,
                            DiaChiGiao=@DiaChiGiao
                            WHERE IdOrder=@IdOrder";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrder", order.IdOrder);
                cmd.Parameters.AddWithValue("@IdUser", order.IdUser);
                cmd.Parameters.AddWithValue("@IdRestaurant", order.IdRestaurant);
                cmd.Parameters.AddWithValue("@TongTien", order.TongTien);
                cmd.Parameters.AddWithValue("@PhiVanChuyen", order.PhiVanChuyen);
                cmd.Parameters.AddWithValue("@TrangThai", order.TrangThai);
                cmd.Parameters.AddWithValue("@DiaChiGiao", order.DiaChiGiao);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool DeleteOrder(int id)
        {
            string query = "DELETE FROM Orders WHERE IdOrder = @Id";

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
