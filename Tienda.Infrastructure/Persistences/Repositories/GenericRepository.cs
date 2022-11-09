using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Helpers;
using Tienda.Infrastructure.Persistences.Contexts;
using Tienda.Infrastructure.Persistences.Interfaces;

namespace Tienda.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TiendaContext context;
        private readonly DbSet<T> entity;
        public GenericRepository(TiendaContext _context)
        {
            context = _context;
            entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await entity.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return data!;
        }
        public async Task<bool> RegisterAsync(T entity)
        {
            await context.AddAsync(entity);
            var registrosAfectados = await context.SaveChangesAsync();
            return registrosAfectados > 0;
        }
        public async Task<bool> EditAsync(T entity)
        {
            context.Update(entity);
            var registrosAfectados = await context.SaveChangesAsync();
            return registrosAfectados > 0;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            context.Remove(entity);
            var registrosAfectados = await context.SaveChangesAsync();
            return registrosAfectados > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = entity;
            if (filter != null) query = query.Where(filter);
            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> query = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) query = query.Paginate(request);
            return query;
        }
    }
}
