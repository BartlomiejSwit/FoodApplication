using FoodApplication.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace FoodApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] FoodProduct value)
        {
            if (value.name == null)
            {
                return "NO-OK";
            }

            return "OK";
        }
        [HttpGet]
        public string Get(string id)
        {
            return id;
        }
    }
}
