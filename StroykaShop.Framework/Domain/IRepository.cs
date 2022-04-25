using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework.Domain
{
    public interface IRepository<in Tkey, T> where T:class
    {
        void Create(T entity);
        T Get(Tkey id);
        List<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expression);


    }
}
