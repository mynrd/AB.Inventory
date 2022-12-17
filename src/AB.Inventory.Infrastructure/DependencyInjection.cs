using AB.Inventory.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AB.Inventory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            services.AddDbContext<ABInventoryContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ABInventoryContext"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)), ServiceLifetime.Transient);

            services.AddScoped<IABInventoryContext>(provider => provider.GetService<ABInventoryContext>());

            services.BuildServiceProvider().GetService<ABInventoryContext>().Database.Migrate();

            return services;
        }
    }
}