using StroykaShop.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Application.Contracts.ProductCategoryApp
{
    public class CreatePrdouctCategory
    {
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
    public class EditProductCategory : CreatePrdouctCategory
    {
        public long Id { get; set; }

    }
    public class PrdouctCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }

    }
    public class ProductCategorySearchModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreatePrdouctCategory command);
        OperationResult Edit(EditProductCategory command);
        List<PrdouctCategoryViewModel> Search(ProductCategorySearchModel command);
        PrdouctCategoryViewModel Get(long id);
        List<PrdouctCategoryViewModel> GetAll();
       

    }

}
