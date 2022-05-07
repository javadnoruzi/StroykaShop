using System.Collections.Generic;
using StroykaShop.Framework;

namespace ShopMangment.Application.Contracts.BrandApp
{
    public interface IBrandApplication{
        OperationResult Create(CreateBrand command);
        OperationResult Edit(EditBrand command);
        BrandViewModel Get(long id);
        List<BrandViewModel> GetAll();
         
    }
}
    
    