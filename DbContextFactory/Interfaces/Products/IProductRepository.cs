using DbContextFactory.Domain;
using DbContextFactory.UOW;

namespace DbContextFactory.Inter.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByIdAsync(int id);
    }

}
