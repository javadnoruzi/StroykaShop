using AccountMangment.Domain.RoleAgg;
using StroykaShop.Framework.Infrastructure;

namespace AccountMangment.Infrastructure.EfCore.Repository
{
    public class RoleRepository:RepositoryBase<long,Role>,IRoleRepository
    {
        private readonly AccountMangmentContext _AccountMangmentContext;

        public RoleRepository(AccountMangmentContext accountMangmentContext):base(accountMangmentContext)
        {
            _AccountMangmentContext = accountMangmentContext;
        }
    }
}