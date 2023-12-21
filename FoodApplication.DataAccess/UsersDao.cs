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
    public class UsersDao : IUsersDao
    {
        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FoodApplicationDB"].ToString();
        }
        public List<Users> GetData()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, FirstName, LastName, Email, UserName, UserPassword FROM dbo.Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                Id = (Guid)reader["Id"],
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
                                Email = Convert.ToString(reader["Email"]),
                                UserName = Convert.ToString(reader["UserName"]),
                                UserPassword = Convert.ToString(reader["UserPassword"])

                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }
        public List<Users> GetUsersById(int Id)
        {
            List<Users> users = new List<Users>();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "SELECT Id, FirstName, LastName, Email, UserName, UserPassword FROM dbo.Users WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                Id = (Guid)reader["Id"],
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
                                Email = Convert.ToString(reader["Email"]),
                                UserName = Convert.ToString(reader["UserName"]),
                                UserPassword = Convert.ToString(reader["UserPassword"])
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;

        }
        public void AddUsers(Users users)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "INSERT INTO dbo.Users (Id, FirstName, LastName, Email, UserName, UserPassword) " +
               "VALUES (@Id, @FirstName, @LastName, @Email, @UserName, @UserPassword)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", users.Id = Guid.NewGuid());
                    command.Parameters.AddWithValue("@FirstName", users.FirstName);
                    command.Parameters.AddWithValue("@LastName", users.LastName);
                    command.Parameters.AddWithValue("@Email", users.Email);
                    command.Parameters.AddWithValue("@UserName", users.UserName);
                    command.Parameters.AddWithValue("@UserPassword", users.UserPassword);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUsers(Users users)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "UPDATE dbo.Users " +
               "SET FirstName = @FirstName, LastName = @LastName, " +
               "Email = @Email, UserName = @UserName, UserPassword = @UserPassword " +
               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", users.Id);
                    command.Parameters.AddWithValue("@FirstName", users.FirstName);
                    command.Parameters.AddWithValue("@LastName", users.LastName);
                    command.Parameters.AddWithValue("@Email", users.Email);
                    command.Parameters.AddWithValue("@UserName", users.UserName);
                    command.Parameters.AddWithValue("@UserPassword", users.UserPassword);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUsers(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string query = "DELETE FROM dbo.Users WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
