using FoodApplication.Core.Domain.Models.Product;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodApplication.Infrastructure.DataInterfaces
{
    public interface IFoodProductDao
    {
        List<FoodProduct> GetData();
        void AddFoodProduct(FoodProduct foodProduct);
        void UpdateFoodProduct(FoodProduct foodProduct);
        void DeleteFoodProduct(int id);

    }
}
