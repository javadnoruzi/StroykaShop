using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShopMangment.Application.Contracts.ProductCategoryApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Adminstretion.Pages.Shop.ProductCategory
{
    public class CreateModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;
        public CreatePrdouctCategory createPrdouctCategory;
        public List<PrdouctCategoryViewModel> categoryViewModels;
        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            categoryViewModels = _productCategoryApplication.GetAllStartMenu();
        }
        public RedirectToPageResult OnPost(CreatePrdouctCategory createPrdouctCategory)
        {
            var create = _productCategoryApplication.Create(createPrdouctCategory);
            if (create.Result)
            {
                return RedirectToPage("/Adminstretion/Index");
            }
            else
            {
                Message = create.Message;
                return RedirectToPage("/Adminstretion/Create");
            }
        }
        public List<PrdouctCategoryViewModel> Getlist(long id)
        {
            return _productCategoryApplication.GetChildern(id);
        }
    }
}
