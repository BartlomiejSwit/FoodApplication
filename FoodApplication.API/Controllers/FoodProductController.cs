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
    public class FoodProductController : ApiController
    {
        public List<FoodProduct> Get(string id)
        {
            try
            {
                var all = new List<FoodProduct>();
                var muDao = new FoodProductDao();
                if (int.TryParse(id, out int intId))
                {
                    if (intId == 0)
                    {
                        all = muDao.GetData();
                    }
                    else
                    {
                        all = muDao.GetFoodProductById(intId);
                    }
                }

                return all;
            }
            catch (Exception ex)
            {
                return new List<FoodProduct>();
            }
        }

        public string Post([FromBody] FoodProduct value)
        {
            try
            {
                var muDao = new FoodProductDao();
                muDao.AddFoodProduct(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put([FromBody] FoodProduct value)
        {
            try
            {
                var muDao = new FoodProductDao();
                muDao.UpdateFoodProduct(value);
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
                var muDao = new FoodProductDao();
                muDao.DeleteFoodProduct(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}