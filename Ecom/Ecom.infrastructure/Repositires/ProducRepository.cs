using AutoMapper;
using Ecom.core.Dtos;
using Ecom.core.Entities.Products;
using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
    }
}
