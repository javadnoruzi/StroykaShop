using System;
using System.Collections.Generic;
using StroykaShop.Framework;

namespace AccountMangment.Application.Contract.AccountApp
{
    public interface IAccountApplication{
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePasswordAccount Command);
        List<AccountViewModel> GetList();
        AccountViewModel Get(long id);
        OperationResult Login(Login commadn);
        

    }
}
