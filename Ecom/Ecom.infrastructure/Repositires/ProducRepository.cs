using Ecom.core.Entities.Products;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;



namespace Ecom.infrastructure.Repositires
{
    internal class ProducRepository : GeniricRepositire<Product>, IProductRepository
    {
        public ProducRepository(AppDbContext context) : base(context)
        {
        }
    }
}
