using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class CompanySite : BaseEntity
    {
        public Guid CompanyId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [InverseProperty("CompanySite")]
        public virtual ICollection<CompanySiteUser> CompanySiteUsers { get; set; }
    }
}