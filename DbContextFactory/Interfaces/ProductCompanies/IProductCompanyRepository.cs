using DbContextFactory.Domain;
using DbContextFactory.UOW;

namespace DbContextFactory.Inter.ProductCompanies
{
    public interface IProductCompanyRepository : IRepository<ProductCompany>
    {
        Task<ProductCompany> GetByIdAsync(int id);
    }

}
