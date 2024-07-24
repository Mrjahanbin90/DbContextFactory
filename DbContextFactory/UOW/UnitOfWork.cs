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
        private ProductRepository _productRepository;
        private CompanyRepository _companyRepository;
      

        public UnitOfWork(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _context = _dbContextFactory.CreateDbContext();
        }

        public IProductRepository Products => _productRepository ??= new(_context);
        public ICompanyRepository Company => _companyRepository ??= new(_context);


        private ProductCompanyRepository _productCompanyRepository;
        public IProductCompanyRepository ProductCompany => _productCompanyRepository ??= new(_context);

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
