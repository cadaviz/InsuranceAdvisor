using InsuranceAdvisor.Domain.Requests;
using InsuranceAdvisor.Domain.Responses;

namespace InsuranceAdvisor.Domain.Services.Interfaces
{
    public interface IInsuranceAdvisorService
    {
        AdviseInsurancePlanResponse AdviseInsurancePlan(AdviseInsurancePlanRequest request);
    }
}
