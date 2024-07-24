using DbContextFactory.Domain;
using DbContextFactory.UOW;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactory.Inter.ProductCompanies
{
    public class ProductCompanyRepository : Repository<ProductCompany>, IProductCompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ProductCompany> GetByIdAsync(int id)
        {
            return await _context.ProductCompanies.FindAsync(id);
        }


    }
}
