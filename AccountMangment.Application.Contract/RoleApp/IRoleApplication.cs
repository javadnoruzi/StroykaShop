using System.Collections.Generic;
using StroykaShop.Framework;

namespace AccountMangment.Application.Contract.RoleApp
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);

        RoleViewModel Get(long id);
        List<RoleViewModel> GetList();
        
    }
}