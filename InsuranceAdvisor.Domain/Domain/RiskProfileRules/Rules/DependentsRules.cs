using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class DependentsRules : RiskProfileRuleBase
    {
        public DependentsRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
        {
            if (riskProfile.HasDependents)
            {
                int riskPointsToAdd = 1;

                _riskPoints.AddToInsuranceLine(InsuranceLine.Home, riskPointsToAdd);
                _riskPoints.AddToInsuranceLine(InsuranceLine.Disability, riskPointsToAdd);
            }

            return _riskPoints;
        }
    }
}
