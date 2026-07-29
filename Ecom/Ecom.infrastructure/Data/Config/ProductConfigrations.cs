using Ecom.core.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Data.Config
{
    internal class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.NEwPrice).HasColumnType("decimal (18,2)");

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Iphone 14",
                    Description = "This is the latest Iphone 14",
                    NEwPrice = 1200,
                    CategoryId = 1
                }
                );
        }
    }
}
