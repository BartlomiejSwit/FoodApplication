using FoodApplication.Core.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Infrastructure.DataInterfaces
{
    public interface IFoodProductListDao
    {
        List<FoodProductList> GetData();
        List<FoodProductList> GetFoodProductListById(int Id);
        void AddFoodProductList(FoodProductList foodProductList);
        void UpdateFoodProductList(FoodProductList foodProductList);
        void DeleteFoodProductList(int id);
    }
}
