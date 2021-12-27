using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class AgeRules : RiskProfileRuleBase
    {
        public AgeRules(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration) : base(riskPoints, rulesConfiguration) { }

        public override RiskScore Evaluate(RiskProfile riskProfile)
        {
            int riskPointsToRemove = default;

            if (riskProfile.Age < _rulesConfiguration.LowRiskLevelAge)
                riskPointsToRemove = 2;
            else if (riskProfile.Age <= _rulesConfiguration.MediumRiskLevelAge)
                riskPointsToRemove = 1;

            _riskPoints.RemoveFromAllInsuranceLines(riskPointsToRemove);

            return _riskPoints;
        }
    }
}
