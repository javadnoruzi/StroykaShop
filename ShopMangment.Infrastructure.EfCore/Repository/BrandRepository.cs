using ShopMangmnet.Domain.BrandAgg;
using StroykaShop.Framework.Infrastructure;

namespace ShopMangment.Infrastructure.EfCore.Repository
{
    public class BrandRepository:RepositoryBase<long,Brand>,IBrandRepository
    {
       private readonly ShopMangmentContext _shopMangmentContext;

        public BrandRepository(ShopMangmentContext shopMangmentContext):base(shopMangmentContext)
        {
            _shopMangmentContext = shopMangmentContext;
        }
    }
}