using Microsoft.Extensions.DependencyInjection;
using ShopMangment.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopMangment.Infrastructure.EfCore.Repository;
using ShopMangmnet.Domain.ProductCategoryAgg;
using ShopMangment.Application;
using ShopMangment.Application.Contracts.ProductCategoryApp;
using StroykaShop.Framework.Infrastructure;
using ShopMangmnet.Domain.BrandAgg;
using ShopMangment.Application.Contracts.BrandApp;

namespace ShopMangmnet.Infrastructure.Bootstrapper
{
    public class ShopMangmentBootstapperr
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitofWork,UnitofWork>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IBrandRepository,BrandRepository>();
            services.AddTransient<IBrandApplication,BrandApplication>();
            services.AddDbContext<ShopMangmentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
