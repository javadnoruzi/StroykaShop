using Microsoft.EntityFrameworkCore;
using AccountMangment.Infrastructure.EfCore.Mapping;
using AccountMangment.Domain.AccountAgg;
namespace AccountMangment.Infrastructure.EfCore
{
    public class AccountMangmentContext : DbContext
    {
       public DbSet<Account> Accounts { get; set; }
        public AccountMangmentContext(DbContextOptions<AccountMangmentContext> Options)
            : base(Options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assmebly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assmebly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
