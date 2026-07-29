using Ecom.core.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Data.Config
{
    internal class PhotoCofigration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasData(new Photo { Id = 1 , Name = "ImageName" , ProductId = 1 });

        }
    }
}
