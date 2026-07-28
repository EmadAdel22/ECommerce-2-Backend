using Ecom.core.Entities.Products;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{
  
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work) : base(work)
        {

        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await work.categoryRepository.GetAllAsync();
                if (categories == null)
                    return BadRequest();
                return Ok(categories);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await work.categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return BadRequest();
                return Ok(category);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CategoryDTo categoryDTO)
        {

            try
            {

                var category = new Category
                {
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description
                };

                if (category == null)
                    return BadRequest();
                await work.categoryRepository.AddAsync(category);
                return Ok(new { message="category has been created" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryDTO)
        {
            try
            {
                var category = new Category()
                {
                   
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description,
                    Id = categoryDTO.Id
                };
                await work.categoryRepository.UpdateAsync(category);
                return Ok(new { message = "category has been updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    } 
}
