using Ecom.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Interfaces
{
    public interface IcustomerBasketReposatory
    {
        Task<CustmoerBasket> GetBasketAsync(string id);
        Task<CustmoerBasket> updateBasketAsync(CustmoerBasket basket);

        Task<bool> DeletBasketAsync(string id);
    }
}
