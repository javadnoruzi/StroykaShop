namespace ShopMangment.Application.Contracts.ProductCategoryApp
{
    public class PrdouctCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
        public string Slug { get;  set; }
        public string Keyword { get;  set; }
        public string MetaDescription { get;  set; }
        public string Descrption { get;  set; }
        public string Picture { get; set; }

    }

}
