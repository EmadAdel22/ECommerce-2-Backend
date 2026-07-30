using AutoMapper;
using Ecom.core.Dtos;
using Ecom.core.Entities.Products;
using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;



namespace Ecom.infrastructure.Repositires
{
    public class ProducRepository : GeniricRepositire<Product>, IProductRepository
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;
        private readonly IImageManagerService imageManagerService;
        public ProducRepository(AppDbContext context, IMapper mapper, IImageManagerService imageManagerService) : base(context)
        {
            this.mapper = mapper;
            this.context = context;
            this.imageManagerService = imageManagerService;
        }

        public async Task<bool> AddAsync(addProductDTO productDTO)
        {
           if (productDTO == null) return false;

            var product = mapper.Map<Product>(productDTO);

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync(); 

            var ImagePath = await imageManagerService.AddImageAysnc(productDTO.Photo,productDTO.Name);

            var photo = ImagePath.Select(path => new Photo
            {
                Name = path,
                ProductId = product.Id


            }).ToList();

            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;


        }

        public async Task DeleteAsync(Product product)
        {
            var findPhoto = await context.Photos.Where(m => m.ProductId == product.Id).ToListAsync();

            foreach (var photo in findPhoto)
            {
                imageManagerService.DeletImageAsync(photo.Name);
            }

             context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(ProductUpdateDTO updateproductDTO)
        {

            if (updateproductDTO == null) return false;

            var Findproduct = await context.Products.Include(x => x.Category)
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == updateproductDTO.Id);
            if(Findproduct == null) return false;

            mapper.Map(updateproductDTO, Findproduct);

            var findPhoto = await context.Photos.Where(m=>m.ProductId == updateproductDTO.Id).ToArrayAsync();

            foreach (var photo in findPhoto)
            {
                 imageManagerService.DeletImageAsync(photo.Name);
               
            }
            context.Photos.RemoveRange(findPhoto);

            var  ImagePath = await imageManagerService.AddImageAysnc(updateproductDTO.Photo, updateproductDTO.Name);

            var photoList = ImagePath.Select(path => new Photo
            {
                Name = path,
                ProductId = updateproductDTO.Id
            }).ToList();

            await context.Photos.AddRangeAsync(photoList);

            await context.SaveChangesAsync();
            return true;



        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync(string sort, int? CategoryId)
        {
            var query = context.Products.Include(m => m.Category)
                .Include(m => m.Photos)
                .AsNoTracking();

            if (CategoryId.HasValue)
                query = query.Where(m => m.CategoryId == CategoryId);
            if(!String.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "PriceAC":
                        query = query.OrderBy(m=> m.NEwPrice);
                        break;
                    case "PriceDes":
                        query = query.OrderByDescending(m=> m.NEwPrice);
                        break;
                    default:
                        query = query.OrderBy(m => m.Name);
                        break;

                }
            }

            var result = mapper.Map<List<ProductDTO>>(query);
            return result;
        }
    }
}
