using AutoMapper;
using Ecom.core.Dtos;
using Ecom.core.Entities.Products;
using Ecom.infrastructure;

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
