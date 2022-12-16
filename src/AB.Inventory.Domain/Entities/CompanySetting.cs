using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class CompanySetting : BaseEntity
    {
        public Guid CompanyId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string SettingName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string SettingValue { get; set; }
    }
}