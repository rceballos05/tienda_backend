using Microsoft.EntityFrameworkCore;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Commons.Bases.Responses;
using Tienda.Infrastructure.Persistences.Contexts;
using Tienda.Infrastructure.Persistences.Interfaces;

namespace Tienda.Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TiendaContext _context) : base(_context)
        {
        }

        public async Task<BaseEntityResponse<Category>> ListCategory(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Category>();
            var category = GetEntityQuery();
            if (!string.IsNullOrEmpty(filters.TextFilter))
            {
                category = category.Where(c => c.Name!.Contains(filters.TextFilter));
            }
            if (filters.Sort is null) filters.Sort = "Id";
            response.TotalRecords = await category.CountAsync();
            response.Items = await Ordering(filters, category).ToListAsync();

            return response;
        }
    }
}
