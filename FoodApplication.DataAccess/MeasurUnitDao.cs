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
    public class MeasurUnitDao : IMeasurUnitDao
    {

        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        }

        public List<MeasurUnit> GetData()
        {
            List<MeasurUnit> measurUnits = new List<MeasurUnit>();

            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, Name, Quantity FROM dbo.MeasurUnit ORDER BY Data";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MeasurUnit measurUnit = new MeasurUnit
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"])
                            };

                            measurUnits.Add(measurUnit);
                        }
                    }
                }
            }

            return measurUnits;
        }

        public void AddMeasurUnit(MeasurUnit measurUnit)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO dbo.MeasurUnit (Name) VALUES (@Name)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", measurUnit.Name);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMeasurUnit(MeasurUnit measurUnit)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "UPDATE dbo.MeasurUnit SET Name = @Name WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", measurUnit.Id);
                    command.Parameters.AddWithValue("@Name", measurUnit.Name);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMeasurUnit(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "DELETE FROM dbo.MeasurUnit WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
