using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework
{
    public interface IFileUpload
    {
        string Upload(IFormFile formFile, string Path);

    }
}
