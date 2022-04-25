using ShopMangment.Application.Contracts.ProductCategoryApp;
using StroykaShop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangmnet.Domain.ProductCategoryAgg
{
   public interface IProductCategoryRepository:IRepository<long,ProducCategory> 
    {
        List<ProductCategoryAgg.ProducCategory> Get(string name);
    }
}
