using Ecom.core.Entities.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Dtos
{
    public record ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal NEwPrice { get; set; }
        public decimal OldPrice { get; set; }
        public List<PhotoDTO> Photos { get; set; } 

        public string CategoryName { get; set; }
    }

    public class ReturnProductDTO
    {
        public List<ProductDTO> Products { get; set; }
        public int TotalCount { get; set; }

    }
    public record PhotoDTO
    {
        public string ImageName { get; set; }

        public int productId { get; set; }
    }

    public record addProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal NEwPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }

        public IFormFileCollection Photo { get; set; }
    }

    public  record  ProductUpdateDTO : addProductDTO
    {
     
        public int Id { get; set; }
    }
}
