namespace DbContextFactory.Domain
{
    public class Company : BaseClass
    {

        /// <summary>
        /// نام شرکت
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<ProductCompany> UserCompanies { get; set; }

    }

}
