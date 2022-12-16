using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class Company : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        [InverseProperty("Company")]
        public ICollection<CompanySite> CompanySites { get; set; }

        [InverseProperty("Company")]
        public ICollection<CompanyUser> CompanyUsers { get; set; }
    }
}