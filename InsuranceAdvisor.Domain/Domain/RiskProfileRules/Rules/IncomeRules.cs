using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class IncomeRules : RiskProfileRuleBase
    {
        public IncomeRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
        {
            decimal _lowRiskIncome = 200000m;
            int riskPointsToRemove = default;

            if (riskProfile.Income > _lowRiskIncome)
                riskPointsToRemove = 1;

            _riskPoints.RemoveFromAllInsuranceLines(riskPointsToRemove);

            return _riskPoints;
        }
    }
}
