using Ecom.core.Entities;
using Ecom.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Repositires
{
    public class customerBasketReposatory : IcustomerBasketReposatory
    {
        public Task<bool> DeletBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustmoerBasket> GetBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustmoerBasket> updateBasketAsync(CustmoerBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
