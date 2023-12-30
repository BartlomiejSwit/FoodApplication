using FoodApplication.Core.Domain.Models.Product;
using FoodApplication.Core.Domain.Models.Users;
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
    public class FoodProductListDao : IFoodProductListDao
    {
        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        }
        public List<FoodProductList> GetData()
        {
            List<FoodProductList> foodProductLists = new List<FoodProductList>();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, FoodProductId, UserId FROM dbo.FoodProductList";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodProductList foodProductList = new FoodProductList
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FoodProductId = Convert.ToInt32(reader["FoodProductId"]),
                                UserId = (Guid)reader["UserId"]

                            };

                            foodProductLists.Add(foodProductList);
                        }
                    }
                }
            }

            return foodProductLists;
        }
        public List<FoodProductList> GetFoodProductListById(int Id)
        {
            List<FoodProductList> foodProductLists = new List<FoodProductList>();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, FoodProductId, UserId FROM dbo.FoodProductList";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodProductList foodProductList = new FoodProductList
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FoodProductId = Convert.ToInt32(reader["FoodProductId"]),
                                UserId = (Guid)reader["UserId"]

                            };

                            foodProductLists.Add(foodProductList);
                        }
                    }
                }
            }

            return foodProductLists;
        }
        public void AddFoodProductList(FoodProductList foodProductList)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO dbo.FoodProductList (FoodProductId, UserId) " +
               "VALUES (@FoodProductId, @UserId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@FoodProductId", foodProductList.FoodProductId);
                    command.Parameters.AddWithValue("@UserId", foodProductList.UserId);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateFoodProductList(FoodProductList foodProductList)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "UPDATE dbo.FoodProductList " +
               "SET FoodProductId = @FoodProductId, UserId = @UserId " +
               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", foodProductList.Id);
                    command.Parameters.AddWithValue("@FoodProductId", foodProductList.FoodProductId);
                    command.Parameters.AddWithValue("@UserId", foodProductList.UserId);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteFoodProductList(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "DELETE FROM dbo.FoodProductList WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
