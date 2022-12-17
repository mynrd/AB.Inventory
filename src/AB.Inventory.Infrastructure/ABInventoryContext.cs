using AB.Inventory.Application.Interfaces;
using AB.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AB.Inventory.Infrastructure
{
    public class ABInventoryContext : DbContext, IABInventoryContext
    {
        public ABInventoryContext(DbContextOptions<ABInventoryContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<CompanySite> CompanySites { get; set; }
        public DbSet<CompanySiteUser> CompanySiteUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}