using FluentValidation;
using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Rules;
using InsuranceAdvisor.Domain.Requests;
using InsuranceAdvisor.Domain.Requests.Validators;
using InsuranceAdvisor.Domain.Services;
using InsuranceAdvisor.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceAdvisor.Domain.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IInsuranceAdvisorService, InsuranceAdvisorService>();
            services.AddScoped<RiskProfileRules>();
            
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AdviseInsurancePlanRequest>, AdviseInsurancePlanRequestValidator>();

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AdviseInsurancePlanRequestValidationConfiguration>(configuration.GetSection(AdviseInsurancePlanRequestValidationConfiguration.Id));
            services.Configure<RiskProfileRulesConfiguration>(configuration.GetSection(RiskProfileRulesConfiguration.Id));

            services.AddSingleton<AdviseInsurancePlanRequestValidationConfiguration>();
            services.AddSingleton<RiskProfileRulesConfiguration>();

            return services;
        }
    }
}
