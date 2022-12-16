using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AB.Inventory.Infrastructure
{
    public class ABInventoryContextFactory : IDesignTimeDbContextFactory<ABInventoryContext>
    {
        public ABInventoryContext CreateDbContext(string[] args)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\AB.Inventory.Infrastructure";
            //File.WriteAllText(@"D:\Temp\Temp1.text", path);
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<ABInventoryContext>();
            var connectionString = configuration.GetConnectionString("ABInventoryContext");

            var optionsBuilder = new DbContextOptionsBuilder<ABInventoryContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new ABInventoryContext(optionsBuilder.Options);
        }
    }
}