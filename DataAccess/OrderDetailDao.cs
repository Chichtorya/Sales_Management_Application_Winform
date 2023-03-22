using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetailDao
    {
        private readonly string _connectionString;

        public OrderDetailDao()
        {
            DbContext context = new DbContext();
            _connectionString = context.GetConnectionString();
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM OrderDetail";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderDetail.ProductId = Convert.ToInt32(reader["ProductId"]);

                    orderDetail.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
                    orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    orderDetail.Discount = Convert.ToSingle(reader["Discount"]);
                    orderDetails.Add(orderDetail);
                }
                reader.Close();
            }
            return orderDetails;
        }

        public OrderDetail GetOrderDetailById(int orderId, int productId)
        {
            OrderDetail orderDetail = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM OrderDetail WHERE OrderId=@OrderId AND ProductId=@ProductId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    orderDetail = new OrderDetail();
                    orderDetail.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderDetail.ProductId = Convert.ToInt32(reader["ProductId"]);

                    orderDetail.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
                    orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    orderDetail.Discount = Convert.ToSingle(reader["Discount"]);
                }
                reader.Close();
            }
            return orderDetail;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount) VALUES (@OrderId, @ProductId, @UnitPrice, @Quantity, @Discount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                command.Parameters.AddWithValue("@ProductId", orderDetail.ProductId);
                
                command.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);
                command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                command.Parameters.AddWithValue("@Discount", orderDetail.Discount);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE OrderDetail SET  UnitPrice=@UnitPrice, Quantity=@Quantity, Discount=@Discount WHERE OrderId=@OrderId AND ProductId=@ProductId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                command.Parameters.AddWithValue("@ProductId", orderDetail.ProductId);
            
                command.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);
                command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                command.Parameters.AddWithValue("@Discount", orderDetail.Discount);
            }
        }
    }
}