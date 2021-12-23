using InsuranceAdvisor.Domain.Requests;

namespace InsuranceAdvisor.Domain.Services.Interfaces
{
    public interface IInsuranceAdvisorService
    {
        void Do(CalculateInsuranceScoreRequest request);
    }
}
