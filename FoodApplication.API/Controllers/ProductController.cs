using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodApplication.API.Controllers
{
    public class ProductController : ApiController
    {
        public string Post([FromBody] string value)
        {
            return value;
        }

    }
}