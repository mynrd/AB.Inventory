using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class CompanyUser : BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}