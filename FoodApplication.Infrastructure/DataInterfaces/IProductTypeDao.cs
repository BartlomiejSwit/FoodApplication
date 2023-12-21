using FoodApplication.Core.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Infrastructure.DataInterfaces
{
    public interface IProductTypeDao
    {
        List<ProductType> GetData();
        List<ProductType> GetProductTypeById(int Id);
        void AddProductType(ProductType productType);
        void UpdateProductType(ProductType productType);
        void DeleteProductType(int id);

    }
}
