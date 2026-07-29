using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Ecom.core.Services
{
    public interface IImageManagerService
    {
        Task<List<string>> AddImageAysnc(IFormFileCollection files, string src);

        Task DeletImageAsync(string src);

    }
}
