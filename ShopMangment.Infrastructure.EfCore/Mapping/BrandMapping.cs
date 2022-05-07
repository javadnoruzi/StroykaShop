using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMangmnet.Domain.BrandAgg;

namespace ShopMangment.Infrastructure.EfCore.Mapping
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.Category).WithMany(x=>x.Brand).HasForeignKey(x=>x.CategoryId);
        }
               
    }
}