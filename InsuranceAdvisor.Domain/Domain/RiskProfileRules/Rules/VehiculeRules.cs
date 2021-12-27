using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class VehiculeRules : RiskProfileRuleBase
    {
        public VehiculeRules(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration) : base(riskPoints, rulesConfiguration) { }

        public override RiskScore Evaluate(RiskProfile riskProfile)
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
            return DateTime.Now.Year - _rulesConfiguration.HighRiskYearsForVehicle;
        }
    }
}
