namespace Tienda.Application.Dtos.Requests
{
    public class ProductDtoRequest
    {
        public string? Name { get; set; } = null;
        public string? UrlImage { get; set; }
        public float? Price { get; set; }
        public int? Discount { get; set; }
        public int? Category { get; set; }
    }
}
