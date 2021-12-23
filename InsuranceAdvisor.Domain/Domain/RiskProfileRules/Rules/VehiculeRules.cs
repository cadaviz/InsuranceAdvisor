using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class VehiculeRules : RiskProfileRuleBase
    {
        public VehiculeRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
        {
            if (riskProfile.HasVehicle && riskProfile.Vehicle.Year >= GetHighRiskYearLimitForProducedVehicle())
            {
                int riskPointsToAdd = 1;

                _riskPoints.AddToInsuranceLine(InsuranceLine.Auto, riskPointsToAdd);
            }

            return _riskPoints;
        }

        private int GetHighRiskYearLimitForProducedVehicle()
        {
            int _highRiskYearsForVehicle = 5;

            return DateTime.Now.Year - _highRiskYearsForVehicle;
        }
    }
}
