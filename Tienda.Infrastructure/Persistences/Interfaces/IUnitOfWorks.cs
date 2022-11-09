namespace Tienda.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWorks : IDisposable
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
