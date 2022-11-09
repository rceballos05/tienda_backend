namespace Tienda.Application.Dtos.Responses
{
    public class ProductDtoResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UrlImage { get; set; }
        public float? Price { get; set; }
        public int? Discount { get; set; }
        public int? Category { get; set; }
    }
}
