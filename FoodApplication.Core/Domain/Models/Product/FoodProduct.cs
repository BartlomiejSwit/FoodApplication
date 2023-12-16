using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Core.Domain.Models.Product
{
    public class FoodProduct
    {
        public virtual int Id { get; set; }
        public virtual int FoodProductBaseId { get; set; }
        public virtual int Quantity { get; set;}

    }
}
