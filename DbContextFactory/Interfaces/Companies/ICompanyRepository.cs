using DbContextFactory.Domain;
using DbContextFactory.UOW;

namespace DbContextFactory.Inter.Companies
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetByIdAsync(int id);
    }

}
