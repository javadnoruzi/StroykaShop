using StroykaShop.Framework;
using System.Collections.Generic;

namespace ShopMangment.Application.Contracts.ProductCategoryApp
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreatePrdouctCategory command);
        OperationResult Edit(EditProductCategory command);
        List<PrdouctCategoryViewModel> Search(ProductCategorySearchModel command);
        PrdouctCategoryViewModel Get(long id);
        List<PrdouctCategoryViewModel> GetAll();
       

    }

}
