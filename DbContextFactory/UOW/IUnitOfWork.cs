using DbContextFactory.Inter.Companies;
using DbContextFactory.Inter.ProductCompanies;
using DbContextFactory.Inter.Products;

namespace DbContextFactory.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IProductRepository Products { get; }
        ICompanyRepository Company { get; }
        IProductCompanyRepository ProductCompany { get; }
    }

}
