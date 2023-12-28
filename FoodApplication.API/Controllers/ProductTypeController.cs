using FoodApplication.Core.Domain.Models.Product;
using FoodApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodApplication.API.Controllers
{
    public class ProductTypeController : ApiController
    {
        public List<ProductType> Get(string id)
        {
            try
            {
                var all = new List<ProductType>();
                var muDao = new ProductTypeDao();
                if (int.TryParse(id, out int intId))
                {

                    if (intId == 0)
                    {
                        all = muDao.GetData();
                        return all;
                    }
                    else
                    {

                        all = muDao.GetProductTypeById(intId);
                        return all;
                    }

                }
                return all;


            }
            catch (Exception ex)
            {
                return new List<ProductType>();
            }
        }

        public string Post([FromBody] ProductType value)
        {
            try
            {
                var muDao = new ProductTypeDao();
                muDao.AddProductType(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Put([FromBody] ProductType value)
        {
            try
            {
                var muDao = new ProductTypeDao();
                muDao.UpdateProductType(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(int value)
        {
            try
            {
                var muDao = new ProductTypeDao();
                muDao.DeleteProductType(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}