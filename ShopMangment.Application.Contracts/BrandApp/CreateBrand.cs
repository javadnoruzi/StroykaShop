using Microsoft.AspNetCore.Http;

namespace ShopMangment.Application.Contracts.BrandApp
{
    public class CreateBrand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public IFormFile Picture{get;set;}
    }
}
    
    