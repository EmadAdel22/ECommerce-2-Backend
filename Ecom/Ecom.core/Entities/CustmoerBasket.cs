using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Entities
{
    public class CustmoerBasket
    {
         
        public CustmoerBasket()
        {
            
        }

        public CustmoerBasket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<BasketItems> Items { get; set; } = new List<BasketItems>();
    }
}
