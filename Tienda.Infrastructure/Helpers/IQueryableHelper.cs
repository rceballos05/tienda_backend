using Tienda.Infrastructure.Commons.Bases.Requests;

namespace Tienda.Infrastructure.Helpers
{
    public static class IQueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPages - 1) * request.Records).Take(request.Records);
        }
    }
}
