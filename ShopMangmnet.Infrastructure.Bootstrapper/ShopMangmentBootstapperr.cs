using Microsoft.Extensions.DependencyInjection;
using ShopMangment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMangment.Infrastructure.EfCore.Repository;
using ShopMangmnet.Domain.ProductCategoryAgg;
using ShopMangment.Application;
using ShopMangment.Application.Contracts.ProductCategoryApp;

namespace ShopMangmnet.Infrastructure.Bootstrapper
{
    public class ShopMangmentBootstapperr
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddDbContext<ShopMangmentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
