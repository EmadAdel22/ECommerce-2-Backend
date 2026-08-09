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

        public CustmoerBasket(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public List<BasketItems> Items { get; set; } = new List<BasketItems>();
    }
}
