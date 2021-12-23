using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class AgeRules : RiskProfileRuleBase
    {
        public AgeRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
        {
            int _lowRiskLevelAge = 30;
            int _mediumRiskLevelAge = 40;

            int riskPointsToRemove = default;

            if (riskProfile.Age < _lowRiskLevelAge)
                riskPointsToRemove = 2;
            else if (riskProfile.Age <= _mediumRiskLevelAge)
                riskPointsToRemove = 1;

            _riskPoints.RemoveFromAllInsuranceLines(riskPointsToRemove);

            return _riskPoints;
        }
    }
}
