using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMangmnet.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Infrastructure.EfCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProducCategory>
    {
        public void Configure(EntityTypeBuilder<ProducCategory> builder)
        {
            builder.ToTable("PrdouctCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();
            builder.HasMany(x=>x.Brand).WithOne(x=>x.Category).HasForeignKey(x=>x.CategoryId);
        }
    }
}
