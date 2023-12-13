using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Core.Domain.Models.Product
{
    internal class FoodProduct
    {
        public virtual int Id { get; set; }
        public virtual int FoodProductBaseId { get; set; }
        public virtual int Quantity { get; set;}
        public virtual List<FoodProductList> FoodProductList { get; set; }
        public virtual int FoodProductId { get; set; }


    }
}
