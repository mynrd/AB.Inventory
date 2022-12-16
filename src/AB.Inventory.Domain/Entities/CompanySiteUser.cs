using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class CompanySiteUser : BaseEntity
    {
        public Guid CompanySiteId { get; set; }
        
        public Guid UserId { get; set; }

        [ForeignKey("CompanySiteId")]
        public CompanySite CompanySite { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}