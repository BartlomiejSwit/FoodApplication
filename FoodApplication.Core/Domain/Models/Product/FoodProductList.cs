using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Core.Domain.Models.Product
{
    public class FoodProductList
    {
        public virtual int id { get; set; }
        public virtual int FoodProductId { get; set; }
        public virtual Guid UserId { get; set; }

    }
}
