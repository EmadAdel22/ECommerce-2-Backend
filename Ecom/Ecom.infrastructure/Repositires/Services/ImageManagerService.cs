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
        public async Task<List<string>> AddImageAysnc(IFormFileCollection files, string src)
        {
            var SaveImagSrc = new List<string>();
            var imageDirectory = Path.Combine("wwwroot", "Images", src);
            if(Directory.Exists(imageDirectory) is not true)
            {
                Directory.CreateDirectory(imageDirectory);
            }

            foreach (var item in files)
            {
                if(item.Length > 0)
                {
                    var ImagName = item.FileName;
                    var ImageSrc =  $"/Images/{src}/{ImagName}";
                    var rootPath = Path.Combine(imageDirectory, ImagName);
                    using (FileStream stream = new FileStream(rootPath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    SaveImagSrc.Add(ImageSrc);
                }

            }
            return SaveImagSrc;
        }

        public void DeletImageAsync(string src)
        {
            var info = _fileProvider.GetFileInfo(src);
            var filePath = info.PhysicalPath;
            File.Delete(filePath);
        }
    }
}
