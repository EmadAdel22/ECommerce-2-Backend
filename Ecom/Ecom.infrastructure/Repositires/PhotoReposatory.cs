using Ecom.core.Entities.Products;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Repositires
{
    public class PhotoReposatory : GeniricRepositire<Photo>, IPhotoRepository
    {
        public PhotoReposatory(AppDbContext context) : base(context)
        {
        }
    }
}
