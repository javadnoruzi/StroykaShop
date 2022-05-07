using StroykaShop.Framework.Infrastructure;

namespace AccountMangment.Infrastructure.EfCore
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AccountMangmentContext context;

        public UnitOfWork(AccountMangmentContext context)
        {
            this.context = context;
        }

        public void BeginTrann()
        {
            context.Database.BeginTransaction();
        }

        public void CommittTran()
        {
            context.Database.CommitTransaction();
        }

        public void RollBackTran()
        {
            context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}