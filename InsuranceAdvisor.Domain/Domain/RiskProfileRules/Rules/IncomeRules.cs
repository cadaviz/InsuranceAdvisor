using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class IncomeRules : RiskProfileRuleBase
    {
        public IncomeRules(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration) : base(riskPoints, rulesConfiguration) { }

        public override RiskScore Evaluate(RiskProfile riskProfile)
        {
            int riskPointsToRemove = default;

            if (riskProfile.Income > _rulesConfiguration.LowRiskIncome)
                riskPointsToRemove = 1;

            _riskPoints.RemoveFromAllInsuranceLines(riskPointsToRemove);

            return _riskPoints;
        }
    }
}
