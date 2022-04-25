using StroykaShop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangmnet.Domain.ProductCategoryAgg
{
    public class ProducCategory : ModelBase<long>
    {
        public string Name { get; private set; }
        public long ParentId { get; private set; }
        public bool IsRemoved { get; private set; }

        public ProducCategory(string name, long parentId)
        {
            Name = name;
            ParentId = parentId;
            IsRemoved = false;
        }
        public void Edit(string name, long parentId)
        {
            Name = name;
            ParentId = parentId;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
