using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework.Infrastructure
{
    public interface IUnitofWork
    {
        void BeginTrann();
        void CommittTran();
        void RollBackTran();
        void SaveChanges();
    }
}
