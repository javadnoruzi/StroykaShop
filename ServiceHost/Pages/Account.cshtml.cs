using AccountMangment.Application.Contract.AccountApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StroykaShop.Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Pages
{
    
    public class AccountModel : PageModel
    {
        [TempData]
        public string RegisterMessage { get; set; }
        [TempData]
        public string LoginMessage { get; set; }
        private readonly IAccountApplication _accountAppliction;
        private readonly ILogger<AccountModel> _logger;
        private readonly IAuthHelper _authHelper;
        public CreateAccount createAccount;
        public Login login;


        public AccountModel(ILogger<AccountModel> logger, IAccountApplication accountAppliction, IAuthHelper authHelper)
        {
            _logger = logger;
            _accountAppliction = accountAppliction;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(Login login)
        {
          var result=  _accountAppliction.Login(login);
            if (result.Result)
            {
                if (_authHelper.Getinfo().RoleId != 2)
                    return RedirectToPage("./Adminstretion/Account");
              return  RedirectToPage("./index");
            }
            else
            {
                LoginMessage = result.Message;
                return RedirectToPage("Account");
               
            }
        }
            
        public RedirectToPageResult OnPostRegister(CreateAccount account)
        {
           var result= _accountAppliction.Create(account);
            if (result.Result)
            {
                
             return RedirectToPage("./index");
            }
            else
            {
                RegisterMessage = result.Message;
                return RedirectToPage("Account");
            }

        }
        public void OnGetSignout()
        {
            _authHelper.SignOut();
        }
    }
}
