using StroykaShop.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Infrastructure.EfCore
{
    public class UnitofWork : IUnitofWork
    {
       
        private readonly ShopMangmentContext context;

        public UnitofWork(ShopMangmentContext context)
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
