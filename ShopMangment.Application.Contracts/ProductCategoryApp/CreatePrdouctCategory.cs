using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StroykaShop.Framework;

namespace ShopMangment.Application.Contracts.ProductCategoryApp
{
    public class CreatePrdouctCategory
    {
        [Required(ErrorMessage =ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        public long ParentId { get; set; }
        public string Slug { get;  set; }
        public string Keyword { get;  set; }
        public string MetaDescription { get;  set; }
        public string Descrption { get;  set; }

        public IFormFile Picture { get; set; }
    }

}
