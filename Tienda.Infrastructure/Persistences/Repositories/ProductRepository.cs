using Microsoft.EntityFrameworkCore;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Commons.Bases.Responses;
using Tienda.Infrastructure.Persistences.Contexts;
using Tienda.Infrastructure.Persistences.Interfaces;

namespace Tienda.Infrastructure.Persistences.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TiendaContext _context) : base(_context)
        {
        }

        public async Task<BaseEntityResponse<Product>> ListProduct(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Product>();
            var product = GetEntityQuery();
            if (!string.IsNullOrEmpty(filters.TextFilter))
            {
                product = product.Where(c => c.Name!.Contains(filters.TextFilter));
            }
            if (filters.Sort is null) filters.Sort = "Id";
            response.TotalRecords = await product.CountAsync();
            response.Items = await Ordering(filters, product).ToListAsync();

            return response;
        }
    }
}
