using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodApplication.API.Controllers
{
    public class ProductListController : ApiController
    {

        // GET: api/ProductList/5
        public string Get(string id)
        {
            return id;
        }

        // POST api/ProductList
        public string Post([FromBody] string value)
        {
            return value;
        }
    }
}