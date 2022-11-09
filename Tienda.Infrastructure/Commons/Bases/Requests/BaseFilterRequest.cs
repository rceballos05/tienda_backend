namespace Tienda.Infrastructure.Commons.Bases.Requests
{
    public class BaseFilterRequest : BasePaginationRequest
    {
        public string? TextFilter { get; set; } = null;
    }
}
