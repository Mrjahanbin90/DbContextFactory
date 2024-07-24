using DbContextFactory.Inter.Companies;
using DbContextFactory.Inter.ProductCompanies;
using DbContextFactory.Inter.Products;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactory.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly ApplicationDbContext _context;
        private IProductRepository _productRepository;
        private ICompanyRepository _companyRepository;
        private IProductCompanyRepository _productCompanyRepository;

        public UnitOfWork(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _context = _dbContextFactory.CreateDbContext();
        }

        public IProductRepository Products
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }
        public ICompanyRepository Company
        {
            get
            {
                return _companyRepository ??= new CompanyRepository(_context);
            }
        }
        public IProductCompanyRepository ProductCompany
        {
            get
            {
                return _productCompanyRepository ??= new ProductCompanyRepository(_context);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
