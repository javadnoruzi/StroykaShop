using AccountMangment.Application;
using AccountMangment.Application.Contract.AccountApp;
using AccountMangment.Application.Contract.RoleApp;
using AccountMangment.Domain.AccountAgg;
using AccountMangment.Domain.RoleAgg;
using AccountMangment.Infrastructure.EfCore;
using AccountMangment.Infrastructure.EfCore.Repository;
using Microsoft.Extensions.DependencyInjection;
using StroykaShop.Framework.Application;
using StroykaShop.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountMangment.Infrastructure.Configuration
{
    public class AccountMangmentBootstrapper
    {
        public static void Configur(IServiceCollection services,string ConnectionString){
          services.AddTransient<IUnitofWork,UnitOfWork>();
          services.AddTransient<IAccountRepository,AccountRepository>();
          services.AddTransient<IAccountApplication,AccountApplication>();
          services.AddTransient<IPasswordHasher,PasswordHasher>();
          services.AddTransient<IRoleRepository,RoleRepository>();
          services.AddTransient<IRoleApplication,RoleApplication>();

          // using Microsoft.EntityFrameworkCore;
         services.AddDbContext<AccountMangmentContext>(x=>x.UseSqlServer(ConnectionString));
          
        }
    }
}