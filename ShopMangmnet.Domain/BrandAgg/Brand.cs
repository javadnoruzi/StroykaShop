using System;
using System.Collections.Generic;
using ShopMangmnet.Domain.ProductCategoryAgg;
using StroykaShop.Framework.Domain;

namespace ShopMangmnet.Domain.BrandAgg
{
    public class Brand : ModelBase<long>
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public ProducCategory Category { get; private set; }
        protected Brand(){}
        public Brand(string name, string picture, string description, long categoryId)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            Description = description;
            CategoryId = categoryId;
        }
        public void Edit(string name, string picture, string description, long categoryId)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            Description = description;
            CategoryId = categoryId;
        }
    }
}