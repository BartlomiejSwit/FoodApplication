using FoodApplication.Core.Domain.Models.Product;
using FoodApplication.Core.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Infrastructure.DataInterfaces
{
    public interface IFoodProductBaseDao
    {
        List<FoodProductBase> GetData();
        List<FoodProductBase> GetFoodProductBaseById(int Id);
        void AddFoodProductBase(FoodProductBase foodProductBase);
        void UpdateFoodProductBase(FoodProductBase foodProductBase);
        void DeleteFoodProductBase(int id);
    }
}
