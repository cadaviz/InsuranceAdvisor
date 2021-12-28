using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class IneligibilityRules : RiskProfileRuleBase
    {
        internal IneligibilityRules(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration) : base(riskPoints, rulesConfiguration) { }

        public override RiskScore Evaluate(RiskProfile riskProfile)
        {
            VerifyUserHasIncome(riskProfile);
            VerifyUserHasVehicle(riskProfile);
            VerifyUserHasHouse(riskProfile);
            VerifyUserAgeLimit(riskProfile);

            return _riskPoints;
        }

        private void VerifyUserHasIncome(RiskProfile riskProfile)
        {
            if (!riskProfile.HasIncome)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Disability);
        }

        private void VerifyUserHasVehicle(RiskProfile riskProfile)
        {
            if (!riskProfile.HasVehicle)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Auto);
        }

        private void VerifyUserHasHouse(RiskProfile riskProfile)
        {
            if (!riskProfile.HasHouse)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Home);
        }

        private void VerifyUserAgeLimit(RiskProfile riskProfile)
        {
            if (riskProfile.Age > _rulesConfiguration.AgeLimitForDisabilityInsurance)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            if (riskProfile.Age > _rulesConfiguration.AgeLimitForLifeInsurance)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Life);
        }
    }
}