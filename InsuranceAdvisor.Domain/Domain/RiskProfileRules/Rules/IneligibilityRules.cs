using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class IneligibilityRules : RiskProfileRuleBase
    {
        internal IneligibilityRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
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
            //TODO: colocar em um arquvio de config
            int _ageLimitForDisabilityInsurance = 60;
            if (riskProfile.Age > _ageLimitForDisabilityInsurance)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            int _ageLimitForLifeInsurance = 60;
            if (riskProfile.Age > _ageLimitForLifeInsurance)
                _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Life);
        }
    }
}