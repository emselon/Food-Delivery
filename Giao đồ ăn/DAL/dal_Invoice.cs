using System.Data;
using DTO;
using Giao_đồ_ăn.DTO;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryAPI.DAL
{
    public class InvoiceDAL
    {
        private readonly string connectionString =
            @"Server=LAPTOP-D716C2N8\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET ALL
        public List<dto_Invoice> GetAllInvoices()
        {
            var list = new List<dto_Invoice>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Invoices";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new dto_Invoice
                    {
                        IdInvoice = (int)reader["IdInvoice"],
                        IdOrder = (int)reader["IdOrder"],
                        SoTien = (decimal)reader["SoTien"],
                        PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString(),
                        TrangThai = (bool)reader["TrangThai"],
                        NgayThanhToan = reader["NgayThanhToan"] == DBNull.Value
                            ? null
                            : (DateTime?)reader["NgayThanhToan"]
                    });
                }
            }
            return list;
        }

        // CREATE
        public bool CreateInvoice(dto_Invoice invoice)
        {
            string query = @"INSERT INTO Invoices
                            (IdOrder, SoTien, PhuongThucThanhToan, TrangThai, NgayThanhToan)
                            VALUES (@IdOrder, @SoTien, @PhuongThucThanhToan, @TrangThai, @NgayThanhToan)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdOrder", invoice.IdOrder);
                cmd.Parameters.AddWithValue("@SoTien", invoice.SoTien);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", invoice.PhuongThucThanhToan);
                cmd.Parameters.AddWithValue("@TrangThai", invoice.TrangThai);
                cmd.Parameters.AddWithValue("@NgayThanhToan", (object?)invoice.NgayThanhToan ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE
        public bool UpdateInvoice(dto_Invoice invoice)
        {
            string query = @"UPDATE Invoices SET
                            IdOrder = @IdOrder,
                            SoTien = @SoTien,
                            PhuongThucThanhToan = @PhuongThucThanhToan,
                            TrangThai = @TrangThai,
                            NgayThanhToan = @NgayThanhToan
                            WHERE IdInvoice = @IdInvoice";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdInvoice", invoice.IdInvoice);
                cmd.Parameters.AddWithValue("@IdOrder", invoice.IdOrder);
                cmd.Parameters.AddWithValue("@SoTien", invoice.SoTien);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", invoice.PhuongThucThanhToan);
                cmd.Parameters.AddWithValue("@TrangThai", invoice.TrangThai);
                cmd.Parameters.AddWithValue("@NgayThanhToan", (object?)invoice.NgayThanhToan ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE
        public bool DeleteInvoice(int id)
        {
            string query = "DELETE FROM Invoices WHERE IdInvoice = @Id";

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
