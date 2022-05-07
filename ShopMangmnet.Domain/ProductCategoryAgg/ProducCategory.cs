using ShopMangmnet.Domain.BrandAgg;
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
        public string Slug { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public string Descrption { get; private set; }
        public string Picture { get; private set; }
        public List<Brand> Brand { get; private set; }
        protected ProducCategory(){}
        public ProducCategory(string name, long parentId, string slug, string keyword, string metaDescription, string descrption, string picture)
        {
            Name = name;
            ParentId = parentId;
            IsRemoved = false;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Descrption = descrption;
            if(!string.IsNullOrWhiteSpace(picture))
            Picture = picture;
        }

        public void Edit(string name, long parentId, string slug, string keyword, string metaDescription, string descrption, string picture)
        {
            Name = name;
            ParentId = parentId;
            IsRemoved = false;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Descrption = descrption;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
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
