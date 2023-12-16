using FoodApplication.Core.Domain;
using FoodApplication.Core.Domain.Models.Product;
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
        public string Post([FromBody] FoodProductBase value)
        {
            if (value.Name == null)
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
