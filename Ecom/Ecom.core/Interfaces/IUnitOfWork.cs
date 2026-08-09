using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public IcustomerBasketReposatory customerBasketReposatory { get; }


    }
}
