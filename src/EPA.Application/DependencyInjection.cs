using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AB.Inventory.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            return services;
        }
    }
}
