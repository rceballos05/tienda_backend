namespace Tienda.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? UrlImage { get; set; }
        public float? Price { get; set; }
        public int? Discount { get; set; }
        public int? Category { get; set; }

        public virtual Category? CategoryNavigation { get; set; }
    }
}
