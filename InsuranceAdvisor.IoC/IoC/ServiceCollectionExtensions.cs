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
    }
}
