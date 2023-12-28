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
    public class FoodProductBaseDao: IFoodProductBaseDao
    {
        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        }
        public List<FoodProductBase> GetData()
        {
            List<FoodProductBase> foodProductBases = new List<FoodProductBase>();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, Name, ProductType, MeasureUnit FROM dbo.FoodProductBase";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodProductBase foodProductBase = new FoodProductBase
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                ProductType = Convert.ToInt32(reader["ProductType"]),
                                MeasureUnit = Convert.ToInt32(reader["MeasureUnit"])

                            };

                            foodProductBases.Add(foodProductBase);
                        }
                    }
                }
            }

            return foodProductBases;
        }
        public List<FoodProductBase> GetFoodProductBaseById(int Id)
        {
            List<FoodProductBase> foodProductBases = new List<FoodProductBase>();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, Name, ProductType, MeasureUnit FROM dbo.FoodProductBase";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodProductBase foodProductBase = new FoodProductBase
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                ProductType = Convert.ToInt32(reader["ProductType"]),
                                MeasureUnit = Convert.ToInt32(reader["MeasureUnit"])

                            };

                            foodProductBases.Add(foodProductBase);
                        }
                    }
                }
            }

            return foodProductBases;
        }
        public void AddFoodProductBase(FoodProductBase foodProductBase)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO dbo.Users (Name, ProductType, MeasureUnit) " +
               "VALUES (@Name, @ProductType, @MeasureUnit)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", foodProductBase.Name);
                    command.Parameters.AddWithValue("@ProductType", foodProductBase.ProductType);
                    command.Parameters.AddWithValue("@MeasureUnit", foodProductBase.MeasureUnit);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateFoodProductBase(FoodProductBase foodProductBase)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "UPDATE dbo.Users " +
               "SET Name = @Name, ProductType = @ProductType, " +
               "MeasureUnit = @MeasureUnit" +
               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", foodProductBase.Id);
                    command.Parameters.AddWithValue("@Name", foodProductBase.Name);
                    command.Parameters.AddWithValue("@ProductType", foodProductBase.ProductType);
                    command.Parameters.AddWithValue("@MeasureUnit", foodProductBase.MeasureUnit);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteFoodProductBase(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "DELETE FROM dbo.FoodProductBase WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
