using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Repositires
{
    internal class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public ICategoryRepository categoryRepository {  get;}

        public IProductRepository ProductRepository { get; }
        public IPhotoRepository photoRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            
            _context = context;
            categoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProducRepository(_context);
            photoRepository = new PhotoReposatory(_context);

        }
    }
}
