using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApplication.Core.Domain.Models.Product
{
    public class FoodProductBase
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int ProductType { get; set; }
        public virtual int MeasureUnit { get; set; }

    }
}
