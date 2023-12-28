using FoodApplication.Core.Domain.Models.Product;
using FoodApplication.Core.Domain.Models.Users;
using FoodApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodApplication.API.Controllers
{
    public class FoodProductBaseController : ApiController
    {
        public List<FoodProductBase> Get(string id)
        {
            try
            {
                var all = new List<FoodProductBase>();
                var muDao = new FoodProductBaseDao();
                if (int.TryParse(id, out int intId))
                {
                    if (intId == 0)
                    {
                        all = muDao.GetData();
                    }
                    else
                    {
                        all = muDao.GetFoodProductBaseById(intId);
                    }
                }

                return all;
            }
            catch (Exception ex)
            {
                return new List<FoodProductBase>();
            }
        }

        public string Post([FromBody] FoodProductBase value)
        {
            try
            {
                var muDao = new FoodProductBaseDao();
                muDao.AddFoodProductBase(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put([FromBody] FoodProductBase value)
        {
            try
            {
                var muDao = new FoodProductBaseDao();
                muDao.UpdateFoodProductBase(value);
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
                var muDao = new FoodProductBaseDao();
                muDao.DeleteFoodProductBase(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}