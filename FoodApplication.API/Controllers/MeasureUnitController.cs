using FoodApplication.Core.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FoodApplication.DataAccess;

namespace FoodApplication.API.Controllers
{
    public class MeasureUnitController : ApiController
    {
        // GET: api/ProductList/5
        public string Get(string id)
        {
            return id;
        }

        // POST api/ProductList
        public string Post([FromBody] MeasurUnit value)
        {


            try
            {
                var muDao = new MeasurUnitDao();
                muDao.AddMeasurUnit(value);
                return "Ok";

            }catch (Exception ex)
            {
                return ex.Message;            
            }


        }

    }
}
