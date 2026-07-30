using System;
using System.Collections.Generic;
using System.Text;
using Ecom.core.Entities.Products;
using Ecom.core.Dtos;

namespace Ecom.core.Interfaces
{
    public interface IProductRepository : IGeniricRepositire<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(string sort, int? CategoryId);

        Task<bool> AddAsync(addProductDTO productDTO);
        Task<bool> UpdateAsync(ProductUpdateDTO updateproductDTO);

        Task DeleteAsync(Product product);



    }
}
