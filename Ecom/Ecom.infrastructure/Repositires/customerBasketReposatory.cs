using Ecom.core.Entities;
using Ecom.core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Ecom.infrastructure.Repositires
{
    public class customerBasketReposatory : IcustomerBasketReposatory
    {
        private readonly IDatabase _database;

        public customerBasketReposatory(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeletBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustmoerBasket> GetBasketAsync(string id)
        {
            var result = await _database.StringGetAsync(id);
            if(!string.IsNullOrEmpty(result))
            {
                return JsonSerializer.Deserialize<CustmoerBasket>(result.ToString());
            }
            return null;
        }

        public async Task<CustmoerBasket> updateBasketAsync(CustmoerBasket basket)
        {
            var _basket = await _database.StringSetAsync(basket.Id , JsonSerializer.Serialize(basket),TimeSpan.FromDays(3));
            if(_basket)
            {
                return await GetBasketAsync(basket.Id);
            }
            return null;
        }
    }
}
