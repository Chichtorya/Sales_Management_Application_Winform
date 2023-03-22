using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDao
    {
        private string _connectionString;

        public ProductDao()
        {
            DbContext context = new DbContext();
            _connectionString = context.GetConnectionString();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Product", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();

                    product.ProductId = (int)reader["ProductId"];
                    product.CategoryId = (int)reader["CategoryId"];
                    product.ProductName = (string)reader["ProductName"];
                    product.Weight = (string)reader["Weight"];
                    product.UnitPrice = (int)reader["UnitPrice"];
                    product.UnitsInStock = (int)reader["UnitsInStock"];

                    productList.Add(product);
                }
            }

            return productList;
        }

        public void SaveAllProducts(List<Product> productList)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("TRUNCATE TABLE Products", connection);
                connection.Open();
                command.ExecuteNonQuery();

                foreach (Product product in productList)
                {
                    command = new SqlCommand("INSERT INTO Product ( CategoryId, ProductName, Weight, UnitPrice, UnitsInStock) " +
                                             "VALUES ( @CategoryId, @ProductName, @Weight, @UnitPrice, @UnitInStock)", connection);

                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                    command.Parameters.AddWithValue("@UnitInStock", product.UnitsInStock);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void addProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Product(CategoryId, ProductName, Weight, UnitPrice, UnitsInStock) VALUES ( @CategoryId, @ProductName, @Weight, @UnitPrice, @UnitInStock)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Weight", product.Weight);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitInStock", product.UnitsInStock);
                connection.Open();
                command.ExecuteNonQuery();


            }


        }
        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Product SET CategoryId=@CategoryId, ProductName=@ProductName ,Weight= @Weight , UnitPrice= @UnitPrice, UnitsInStock= @UnitInStock WHERE ProductId=@ProductId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Weight", product.Weight);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitInStock", product.UnitsInStock);
                command.Parameters.AddWithValue("@ProductId", product.ProductId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Product WHERE ProductId=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Product GetProductById(int id)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Product WHERE ProductId=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product();
                    product.ProductId = Convert.ToInt32(reader["ProductId"]);

                    product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    product.ProductName = Convert.ToString(reader["ProductName"]);
                    product.Weight = Convert.ToString(reader["Weight"]);
                    product.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
                    product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                }
                reader.Close();
            }
            return product;
        }
    }
}
