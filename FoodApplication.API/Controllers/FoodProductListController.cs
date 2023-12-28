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
    public class FoodProductListController : ApiController
    {
        public List<FoodProductList> Get(string id)
        {
            try
            {
                var all = new List<FoodProductList>();
                var muDao = new FoodProductListDao();
                if (int.TryParse(id, out int intId))
                {
                    if (intId == 0)
                    {
                        all = muDao.GetData();
                    }
                    else
                    {
                        all = muDao.GetFoodProductListById(intId);
                    }
                }

                return all;
            }
            catch (Exception ex)
            {
                return new List<FoodProductList>();
            }
        }

        public string Post([FromBody] FoodProductList value)
        {
            try
            {
                var muDao = new FoodProductListDao();
                muDao.AddFoodProductList(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put([FromBody] FoodProductList value)
        {
            try
            {
                var muDao = new FoodProductListDao();
                muDao.UpdateFoodProductList(value);
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
                var muDao = new FoodProductListDao();
                muDao.DeleteFoodProductList(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}