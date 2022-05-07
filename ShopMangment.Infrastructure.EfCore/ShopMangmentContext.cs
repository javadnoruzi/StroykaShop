using Microsoft.EntityFrameworkCore;
using ShopMangment.Infrastructure.EfCore.Mapping;
using ShopMangmnet.Domain.BrandAgg;
using ShopMangmnet.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Infrastructure.EfCore
{
    public class ShopMangmentContext : DbContext
    {
        public DbSet<ProducCategory> ProducCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public ShopMangmentContext(DbContextOptions<ShopMangmentContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assmebly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assmebly);
            base.OnModelCreating(modelBuilder);
        }
        /* public ShopMangmentContext CreateDbContext(string[] args)
         {
            
             var builder = new DbContextOptionsBuilder<ShopMangmentContext>();
 
             var connectionString = "Data Source=.;Initial Catalog=Stroyka;Integrated Security=true;";
 
             builder.UseSqlServer(connectionString);
 
             return new ShopMangmentContext(builder.Options);
         }*/

    }
}
