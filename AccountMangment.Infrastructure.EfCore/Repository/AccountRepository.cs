using AccountMangment.Domain.AccountAgg;
using StroykaShop.Framework.Infrastructure;
using System.Linq;
namespace AccountMangment.Infrastructure.EfCore.Repository
{
    public class AccountRepository:RepositoryBase<long,Account>,IAccountRepository
    {
        private readonly AccountMangmentContext _accountMangmentContext;

        public AccountRepository(AccountMangmentContext accountMangmentContext):base(accountMangmentContext)
        {
            _accountMangmentContext = accountMangmentContext;
        }

        public Account Get(string UnserName)
        {
            return _accountMangmentContext.Accounts.FirstOrDefault(x=>x.UserName==UnserName);
        }

        public Account GetbyMobile(string Mobile)
        {
            return _accountMangmentContext.Accounts.FirstOrDefault(x => x.Mobile==Mobile);
        }

        public Account GetEmail(string Emial)
        {
            return _accountMangmentContext.Accounts.FirstOrDefault(x => x.Email ==Emial);
        }
    }
}