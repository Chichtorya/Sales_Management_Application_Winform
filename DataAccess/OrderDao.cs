
using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class OrderDao
    {
        private readonly string _connectionString;

        public OrderDao()
        {
            DbContext context = new DbContext();
            _connectionString = context.GetConnectionString();
        }
        public DataTable GetSalesReport(DateTime startDate, DateTime endDate)
        {
            DataTable reportData = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
          SELECT [MemberId], SUM([Freight]) AS [TotalSales]
FROM [FStore].[dbo].[Order]
WHERE [OrderDate] >= @StartDate AND [OrderDate] < @EndDate
GROUP BY [MemberId]
ORDER BY [TotalSales] DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reportData.Load(reader);
                reader.Close();
            }
            return reportData;
        }
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [Order]";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderId = Convert.ToInt32(reader["OrderId"]);
                    order.MemberId = Convert.ToInt32(reader["MemberId"]);
                    order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    order.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                    order.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
                    order.Freight = Convert.ToInt32(reader["Freight"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            return orders;
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [Order] WHERE OrderId=@OrderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    order = new Order();
                    order.OrderId = Convert.ToInt32(reader["OrderId"]);
                    order.MemberId = Convert.ToInt32(reader["MemberId"]);
                    order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    order.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                    order.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
                    order.Freight = Convert.ToInt32(reader["Freight"]);
                }
                reader.Close();
            }
            return order;
        }

        public void AddOrder(Order order)
        {
            string formattedDate1 = order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");

            string formattedDate2 = order.RequiredDate.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedDate3 = order.ShippedDate.ToString("yyyy-MM-dd HH:mm:ss");
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO [Order] (MemberId, OrderDate, RequiredDate, ShippedDate, Freight) VALUES (@MemberId, @OrderDate, @RequiredDate, @ShippedDate, @Freight)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberId", order.MemberId);
                command.Parameters.AddWithValue("@OrderDate", formattedDate1);
                command.Parameters.AddWithValue("@RequiredDate", formattedDate2);
                command.Parameters.AddWithValue("@ShippedDate", formattedDate3);
                command.Parameters.AddWithValue("@Freight", order.Freight);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateOrder(Order order)
        {
            
                if (order.OrderDate >= SqlDateTime.MinValue.Value && order.OrderDate <= SqlDateTime.MaxValue.Value &&
             (order.RequiredDate == null || (order.RequiredDate >= SqlDateTime.MinValue.Value && order.RequiredDate <= SqlDateTime.MaxValue.Value)) &&
             (order.ShippedDate == null || (order.ShippedDate >= SqlDateTime.MinValue.Value && order.ShippedDate <= SqlDateTime.MaxValue.Value)))
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        string query = "UPDATE [Order] SET OrderDate=@OrderDate, RequiredDate=@RequiredDate, ShippedDate=@ShippedDate, Freight=@Freight WHERE OrderId=@OrderId && MemberId=@MemberId";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MemberId", order.MemberId);
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                        command.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                        command.Parameters.AddWithValue("@Freight", order.Freight);
                        command.Parameters.AddWithValue("@OrderId", order.OrderId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            
        }
        public void DeleteOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM [Order] WHERE OrderId=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Order> GetOrderListById(int memberid) {
            Order order = null;
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [Order] WHERE MemberId=@MemberId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberId", memberid);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    order = new Order();
                    order.OrderId = Convert.ToInt32(reader["OrderId"]);
                    order.MemberId = Convert.ToInt32(reader["MemberId"]);
                    order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    order.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                    order.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
                    order.Freight = Convert.ToInt32(reader["Freight"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            return orders;
        }
    }
}
