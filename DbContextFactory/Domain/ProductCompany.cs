using System.ComponentModel.DataAnnotations.Schema;

namespace DbContextFactory.Domain
{
    public class ProductCompany : BaseClass
    {

        public int ProductId { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

    }

}
