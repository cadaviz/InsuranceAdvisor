using InsuranceAdvisor.Domain.Services;
using InsuranceAdvisor.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceAdvisor.Domain.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IInsuranceAdvisorService, InsuranceAdvisorService>();

            return services;
        }
    }
}
