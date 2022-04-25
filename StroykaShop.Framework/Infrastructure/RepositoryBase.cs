using Microsoft.EntityFrameworkCore;
using StroykaShop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework.Infrastructure
{
    public class RepositoryBase<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            dbContext.Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Any(expression);
        }

        public T Get(Tkey id)
        {
            return dbContext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }
    }
}
