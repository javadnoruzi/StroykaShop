using Microsoft.Extensions.DependencyInjection;
using ShopMangment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ShopMangmnet.Infrastructure.Bootstrapper
{
    public class ShopMangmentBootstapperr
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddDbContext<ShopMangmentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
