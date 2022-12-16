using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        public bool? IsSystemRole { get; set; }

        [InverseProperty("Role")]
        public ICollection<UserRole> UserRoles { get; set; }
    }
}