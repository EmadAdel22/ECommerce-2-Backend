using AutoMapper;
using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Repositires
{
    internal class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagerService _imageManagerService;
        public ICategoryRepository categoryRepository {  get;}

        public IProductRepository ProductRepository { get; }
        public IPhotoRepository photoRepository { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagerService imageManagerService)
        {

            _context = context;
            _mapper = mapper;
            _imageManagerService = imageManagerService;
            categoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProducRepository(_context , _mapper, _imageManagerService);
            photoRepository = new PhotoReposatory(_context);
        
        }
    }
}
