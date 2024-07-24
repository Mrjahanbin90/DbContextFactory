namespace DbContextFactory.Domain
{

    public class Product : BaseClass
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductCompany> UserCompanies { get; set; }
    }
}
