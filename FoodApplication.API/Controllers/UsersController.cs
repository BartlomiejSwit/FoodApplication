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
    public class UsersController : ApiController
    {
        // GET: Users
        public List<Users> Get(string id)
        {
            try
            {
                var all = new List<Users>();
                var muDao = new UsersDao();
                if (int.TryParse(id, out int intId))
                {
                    if (intId == 0)
                    {
                        all = muDao.GetData();
                    }
                    else
                    {
                        all = muDao.GetUsersById(intId);
                    }
                }

                return all;
            }
            catch (Exception ex)
            {
                return new List<Users>();
            }
        }

        public string Post([FromBody] Users value)
        {
            try
            {
                var muDao = new UsersDao();
                muDao.AddUsers(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put([FromBody] Users value)
        {
            try
            {
                var muDao = new UsersDao();
                muDao.UpdateUsers(value);
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
                var muDao = new UsersDao();
                muDao.DeleteUsers(value);
                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}