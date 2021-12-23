using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;
using InsuranceAdvisor.Domain.Requests;
using InsuranceAdvisor.Domain.Services.Interfaces;

namespace InsuranceAdvisor.Domain.Services
{
    internal class InsuranceAdvisorService : IInsuranceAdvisorService
    {
        public void Do(CalculateInsuranceScoreRequest request)
        {
            var riskProfile = CreateRiskProfile(request);
            var result = new RiskProfileRules().Validate(riskProfile);

        }

        private RiskProfile CreateRiskProfile(CalculateInsuranceScoreRequest request)
        {
            return new RiskProfile(age: request.Age,
                                   dependents: request.Dependents,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: request.Income,
                                   maritalStatus: request.MaritalStatus,
                                   riskQuestions: null,
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }
    }
}
