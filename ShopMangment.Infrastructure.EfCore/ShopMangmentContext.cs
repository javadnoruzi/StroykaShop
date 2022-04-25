using Microsoft.EntityFrameworkCore;
using ShopMangment.Infrastructure.EfCore.Mapping;
using ShopMangmnet.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Infrastructure.EfCore
{
    public class ShopMangmentContext:DbContext
    {
        public DbSet<ProducCategory>  ProducCategories { get; set; }
        public ShopMangmentContext(DbContextOptions<ShopMangmentContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assmebly = typeof(ProductCategoryMapping).Assembly;
            base.OnModelCreating(modelBuilder);
        }
    }
}
