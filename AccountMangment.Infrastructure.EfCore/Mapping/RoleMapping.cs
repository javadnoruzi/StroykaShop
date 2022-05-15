using AccountMangment.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangment.Infrastructure.EfCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
           builder.ToTable("Roles");
           builder.HasKey(x=>x.Id);
           builder.Property(x=>x.Name).IsRequired();
            builder.HasMany(x => x.Accounts).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            builder.OwnsMany<Permissions>(x => x.Permissions, NavigationBuilder => {
                NavigationBuilder.ToTable("RolePermissions");
                NavigationBuilder.HasKey(x => x.Id);
                NavigationBuilder.WithOwner(x => x.Role);
            });
        }
    }
}