using ShopMangmnet.Domain.ProductCategoryAgg;
using StroykaShop.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProducCategory>, IProductCategoryRepository
    {
        private readonly ShopMangmentContext mangmentContext;

        public ProductCategoryRepository(ShopMangmentContext mangmentContext):base(mangmentContext)
        {
            this.mangmentContext = mangmentContext;
        }

        public List<ProducCategory> Get(string name)
        {
           
            return mangmentContext.ProducCategories.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
