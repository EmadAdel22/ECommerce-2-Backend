using AutoMapper;
using Ecom.Api.Helper;
using Ecom.core.Dtos;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{
   
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-all")]

        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await work.ProductRepository.GetAllAsync(x => x.Category, x=> x.Photos);
                var result = mapper.Map<List<ProductDTO>>(products);
                if (products == null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
