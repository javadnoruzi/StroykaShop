using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaQuery.Contracs.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public long ParentId { get;  set; }
        public string ParentName { get; set; }
        public bool IsRemoved { get;  set; }
        public string Slug { get;  set; }
        public string Keyword { get;  set; }
        public string MetaDescription { get;  set; }
        public string Descrption { get;  set; }
    }
}
