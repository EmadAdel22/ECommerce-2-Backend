using Ecom.core.Dtos;
using Ecom.core.Entities.Products;
using Ecom.core.Sharing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Interfaces
{
    public interface IProductRepository : IGeniricRepositire<Product>
    {
        Task<ReturnProductDTO> GetAllAsync(ProducParams producParams );

        Task<bool> AddAsync(addProductDTO productDTO);
        Task<bool> UpdateAsync(ProductUpdateDTO updateproductDTO);

        Task DeleteAsync(Product product);



    }
}
