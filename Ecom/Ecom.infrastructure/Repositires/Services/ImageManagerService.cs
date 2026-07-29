using Ecom.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.infrastructure.Repositires.Services
{
    public class ImageManagerService : IImageManagerService
    {
         private readonly IFileProvider _fileProvider;
        public ImageManagerService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public Task<List<string>> AddImageAysnc(IFormFileCollection files, string src)
        {
            throw new NotImplementedException();
        }

        public Task DeletImageAsync(string src)
        {
            throw new NotImplementedException();
        }
    }
}
