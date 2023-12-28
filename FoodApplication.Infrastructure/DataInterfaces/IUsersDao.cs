using FoodApplication.Core.Domain.Models.Product;
using FoodApplication.Core.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Infrastructure.DataInterfaces
{
    public interface IUsersDao
    {
        List<Users> GetData();
        List<Users> GetUsersById(int Id);
        void AddUsers(Users users);
        void UpdateUsers(Users users);
        void DeleteUsers(string id);

    }
}
