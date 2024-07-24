using System.ComponentModel.DataAnnotations;

namespace DbContextFactory.Domain
{
    public class BaseClass
    {
        [Key]
        public int Id { get; set; }
    }

}
