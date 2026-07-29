using AutoMapper;
using Ecom.core.Dtos;
using Ecom.core.Entities.Products;
using Ecom.infrastructure;

namespace Ecom.Api.Mapping
{
    public class productMapping : Profile
    {
        public productMapping()
        {
            CreateMap<Product, ProductDTO>
                ().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
            CreateMap<Photo, PhotoDTO>().ReverseMap();

            CreateMap<addProductDTO, Product>().ForMember(dest => dest.Photos, opt => opt.Ignore()).ReverseMap();

            CreateMap<ProductUpdateDTO, Product>().ForMember(dest => dest.Photos, opt => opt.Ignore()).ReverseMap();
        }
    }
}
