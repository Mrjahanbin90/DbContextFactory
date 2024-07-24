using DbContextFactory.Domain;
using DbContextFactory.UOW;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactory.Inter.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
