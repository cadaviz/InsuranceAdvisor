using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;
using InsuranceAdvisor.Domain.Requests;
using InsuranceAdvisor.Domain.Responses;
using InsuranceAdvisor.Domain.Services.Interfaces;

namespace InsuranceAdvisor.Domain.Services
{
    internal class InsuranceAdvisorService : IInsuranceAdvisorService
    {
        private readonly RiskProfileRules _riskProfileRules;

        public InsuranceAdvisorService(RiskProfileRules riskProfileRules)
        {
            _riskProfileRules = riskProfileRules;
        }

        public AdviseInsurancePlanResponse AdviseInsurancePlan(AdviseInsurancePlanRequest request)
        {
            var riskProfile = CreateRiskProfile(request);
            var riskPoints = _riskProfileRules.Evaluate(riskProfile);

            var insurancePlanAdvise = new InsurancePlanAdvise(riskPoints);

            return CreateAdviseInsurancePlanResponse(insurancePlanAdvise);
        }

        private RiskProfile CreateRiskProfile(AdviseInsurancePlanRequest request)
        {
            return new RiskProfile(age: request.Age,
                                   dependents: request.Dependents,
                                   house: CreateHouseInformation(request.House),
                                   income: request.Income,
                                   maritalStatus: request.MaritalStatus.Value,
                                   riskQuestions: CreateRiskQuestions(request.RiskQuestions),
                                   vehicle: CreateVehicleInformation(request.Vehicle));
        }

        private HouseInformation? CreateHouseInformation(HouseInformationRequest? houseInformationRequest)
        {
            if (houseInformationRequest is null)
                return null;

            return new HouseInformation(houseInformationRequest.OwnershipStatus.Value);
        }

        private bool[] CreateRiskQuestions(int[] riskQuestionsRequest)
        {
            return riskQuestionsRequest.Select(x => x == 1).ToArray();
        }

        private VehicleInformation? CreateVehicleInformation(VehicleInformationRequest? vehicleInformationRequest)
        {
            if (vehicleInformationRequest is null)
                return null;

            return new VehicleInformation(vehicleInformationRequest.Year);
        }

        private AdviseInsurancePlanResponse CreateAdviseInsurancePlanResponse(InsurancePlanAdvise insurancePlanAdvise)
        {
            return new AdviseInsurancePlanResponse(auto: insurancePlanAdvise.Plan[InsuranceLine.Auto],
                                                   disability: insurancePlanAdvise.Plan[InsuranceLine.Disability],
                                                   home: insurancePlanAdvise.Plan[InsuranceLine.Home],
                                                   life: insurancePlanAdvise.Plan[InsuranceLine.Life]);
        }
    }
}
