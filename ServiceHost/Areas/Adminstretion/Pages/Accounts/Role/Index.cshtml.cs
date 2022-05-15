using AccountMangment.Application.Contract.RoleApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShopMangment.Application.Contracts.ProductCategoryApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Adminstretion.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public List<RoleViewModel> Roles;
        public RoleViewModel searchModel;

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles= _roleApplication.GetList();
        }
        public void OnPost(ProductCategorySearchModel searchModel)
        {
           

        }
    }
}
