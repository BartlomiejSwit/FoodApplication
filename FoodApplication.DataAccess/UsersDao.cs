using FoodApplication.Infrastructure.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
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



    }
}
