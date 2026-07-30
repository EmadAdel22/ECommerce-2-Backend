using AutoMapper;
using Ecom.Api.Helper;
using Ecom.core.Dtos;
using Ecom.core.Entities.Products;
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

        public async Task<IActionResult> GetAllProducts(string? sort , int? CategoryId)
        {
            try
            {
                var products = await work.ProductRepository
                    .GetAllAsync(sort , CategoryId);
                
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-Id/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await work.ProductRepository.GetByIdAsync(id, x => x.Category, x => x.Photos);
                var result = mapper.Map<ProductDTO>(product);
                if (product == null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] addProductDTO productDTO)
        {
            try
            {
               await work.ProductRepository.AddAsync(productDTO);
                return Ok(new ResponseAPI(200, "Product Added Successfully"));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO updateproductDTO)
        {
            try
            {
                await work.ProductRepository.UpdateAsync(updateproductDTO);
                return Ok(new ResponseAPI(200, "Product Updated Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await work.ProductRepository.GetByIdAsync(id, x => x.Photos , x => x.Category );
                if (product == null)
                    return BadRequest(new ResponseAPI(400, "Product Not Found"));
             
                await work.ProductRepository.DeleteAsync(product);
                return Ok(new ResponseAPI(200, "Product Deleted Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
