﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Application.Contracts.ProductCategoryApp
{
    public class CreatePrdouctCategory
    {
        public string Name { get; set; }
        public long ParentId { get; set; }
        public string Slug { get;  set; }
        public string Keyword { get;  set; }
        public string MetaDescription { get;  set; }
        public string Descrption { get;  set; }
    }

}
