using Microsoft.EntityFrameworkCore;

namespace AB.Inventory.Application.Interfaces
{
    using AB.Inventory.Domain.Entities;

    public interface IABInventoryContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<CompanySetting> CompanySettings { get; set; }
        DbSet<CompanySite> CompanySites { get; set; }
        DbSet<CompanySiteUser> CompanySiteUsers { get; set; }
        DbSet<CompanyUser> CompanyUsers { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}