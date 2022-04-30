using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StroykaShop.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile formFile, string Path)
        {

            if (formFile == null) return string.Empty;

            var Directorypath = _webHostEnvironment.WebRootPath + $"//ProductCategories//{Path}";
            if (Directory.Exists(Directorypath))
                Directory.CreateDirectory(Directorypath);

            string Filename = DateTime.Now + "-" + formFile.FileName;
            string FilePath = Directorypath + "//" + Filename;
            using (var output = File.Create(FilePath))
            {
                formFile.CopyTo(output);
            }
            return FilePath;

        }
    }
}
