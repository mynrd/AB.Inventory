using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AB.Inventory.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string PasswordHash { get; set; }

        [Column(TypeName = "int")]
        public UserStatus? Status { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? EmailConfirmed { get; set; }

        [InverseProperty("User")]
        public ICollection<UserRole> UserRoles { get; set; }

        [InverseProperty("User")]
        public ICollection<CompanySiteUser> CompanySiteUsers { get; set; }

        [InverseProperty("User")]
        public ICollection<CompanyUser> CompanyUsers { get; set; }
    }

    public enum UserStatus : int
    {
        Active = 1,
        Inactive = 2,
        Locked = 3,
        Suspended = 4,
    }
}