using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Commons.Bases.Responses;

namespace Tienda.Infrastructure.Persistences.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<BaseEntityResponse<Product>> ListProduct(BaseFilterRequest filters);
    }
}
