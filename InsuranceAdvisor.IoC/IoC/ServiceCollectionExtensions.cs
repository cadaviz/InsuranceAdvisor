using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceAdvisor.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services = Domain.IoC.ServiceCollectionExtensions.AddInternalServices(services);

            return services;
        }

        public static IServiceCollection AddValidators (this IServiceCollection services)
        {
            services = Domain.IoC.ServiceCollectionExtensions.AddValidators(services);

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services = Domain.IoC.ServiceCollectionExtensions.AddConfigurations(services, configuration);

            return services;
        }
    }
}
