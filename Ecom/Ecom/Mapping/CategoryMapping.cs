using AutoMapper;
using Ecom.core.Entities.Products;
using Ecom.infrastructure.Dtos;
namespace Ecom.Api.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTo, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

        }
    }
}
