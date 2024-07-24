using DbContextFactory.Domain;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactory.UOW
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ProductCompany> ProductCompanies { get; set; }
    }

}
