using DbContextFactory.Domain;
using DbContextFactory.UOW;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactory.Inter.Companies
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }
    }
}
