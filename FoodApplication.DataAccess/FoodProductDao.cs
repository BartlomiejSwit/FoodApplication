using FoodApplication.Infrastructure.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FoodApplication.Core.Domain.Models.Product;

namespace FoodApplication.DataAccess
{
    public class FoodProductDao : IFoodProductDao
    {
        //public static string ConnectionString()
        //{
        //    string cstring = string.Empty;
        //    cstring = ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        //    return cstring;
        //}


        //public DataTable GetData()
        //{
        //    DataTable dataTable = null;
        //    using (SqlConnection connection = new SqlConnection(ConnectionString()))
        //    {
        //        connection.Open();
        //        string query = "Select OfferId, Name, path, Answer, Data From dbo.Oferty_pracy Order by Data";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            command.ExecuteNonQuery();
        //            dataTable = new DataTable();
        //            adapter.Fill(dataTable);
        //        }

        //    }

        //    return dataTable;
        //}

        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        }

        public List<FoodProduct> GetData()
        {
            List<FoodProduct> foodProducts = new List<FoodProduct>();

            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, FoodProductBaseId, Quantity FROM dbo.FoodProduct ORDER BY Data";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodProduct foodProduct = new FoodProduct
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FoodProductBaseId = Convert.ToInt32(reader["FoodProductBaseId"]),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };

                            foodProducts.Add(foodProduct);
                        }
                    }
                }
            }

            return foodProducts;
        }

        public void AddFoodProduct(FoodProduct foodProduct)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO dbo.FoodProduct (FoodProductBaseId, Quantity) VALUES (@FoodProductBaseId, @Quantity)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FoodProductBaseId", foodProduct.FoodProductBaseId);
                    command.Parameters.AddWithValue("@Quantity", foodProduct.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateFoodProduct(FoodProduct foodProduct)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "UPDATE dbo.FoodProduct SET FoodProductBaseId = @FoodProductBaseId, Quantity = @Quantity WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", foodProduct.Id);
                    command.Parameters.AddWithValue("@FoodProductBaseId", foodProduct.FoodProductBaseId);
                    command.Parameters.AddWithValue("@Quantity", foodProduct.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFoodProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "DELETE FROM dbo.FoodProduct WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
