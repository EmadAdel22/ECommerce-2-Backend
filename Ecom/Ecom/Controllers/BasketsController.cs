using AutoMapper;
using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Repositires;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{

    public class BasketsController : BaseController
    {
        public BasketsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-basket-item/{id}")]

        public async Task<IActionResult> getBasketItems(string id)
        {
            var result = await work.customerBasketReposatory.GetBasketAsync(id);
            if (result is null) {

                return Ok(new CustmoerBasket());
            }
            return Ok(result);
        }

        [HttpPost("update-basket")]

        public async Task<IActionResult> AddItem(CustmoerBasket basket)   
        {
            var _basket = await work.customerBasketReposatory.updateBasketAsync(basket);
            return Ok(basket);

        }

        [HttpDelete("delet-basket-item/{id}")]
        public async Task<IActionResult> DeletItem(string id)
        {
           var result = await work.customerBasketReposatory.DeletBasketAsync(id);
            return result ? Ok("Item Ddeleted") : BadRequest();
        }

    }
}
