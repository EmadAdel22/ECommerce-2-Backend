using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecom.core.Entities.Products
{
    public class Photo : BaseEntity<int>
    {
        public string Name { get; set; }

        public int ProductId { get; set; }
        //[ForeignKey (nameof(ProductId))]

        //public virtual Product Product { get; set; }
    }
}
