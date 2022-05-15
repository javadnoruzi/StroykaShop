using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShopMangment.Application.Contracts.ProductCategoryApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Adminstretion.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public List<PrdouctCategoryViewModel> prdouctCategories;
        public ProductCategorySearchModel searchModel;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            prdouctCategories= _productCategoryApplication.GetAll();
        }
        public void OnPost(ProductCategorySearchModel searchModel)
        {
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
            prdouctCategories = _productCategoryApplication.Search(searchModel);
            else
                prdouctCategories = _productCategoryApplication.GetAll();

        }
    }
}
