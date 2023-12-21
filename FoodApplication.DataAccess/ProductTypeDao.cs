using FoodApplication.Core.Domain.Models.Product;
using FoodApplication.Infrastructure.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.DataAccess
{
    public class ProductTypeDao : IProductTypeDao
    {
        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        }
        public List<ProductType> GetData()
        {
            List<ProductType> productTypes = new List<ProductType>();

            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, Name FROM dbo.ProductType";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductType productType = new ProductType
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"])
                            };

                            productTypes.Add(productType);
                        }
                    }
                }
            }

            return productTypes;
        }
        public List<ProductType> GetProductTypeById(int Id)
        {
            List<ProductType> productTypes = new List<ProductType>();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, Name FROM dbo.ProductType WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductType productType = new ProductType
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"])
                            };

                            productTypes.Add(productType);
                        }
                    }
                }
            }

            return productTypes;

        }
        public void AddProductType(ProductType productType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO dbo.ProductType (Name) VALUES (@Name)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", productType.Name);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProductType(ProductType productType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "UPDATE dbo.ProductType SET Name = @Name WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", productType.Id);
                    command.Parameters.AddWithValue("@Name", productType.Name);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProductType(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "DELETE FROM dbo.ProductType WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
