namespace Tienda.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
