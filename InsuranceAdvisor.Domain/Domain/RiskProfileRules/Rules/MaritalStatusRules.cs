using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class MaritalStatusRules : RiskProfileRuleBase
    {
        public MaritalStatusRules(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration) : base(riskPoints, rulesConfiguration) { }

        public override RiskScore Evaluate(RiskProfile riskProfile)
        {
            if (riskProfile.MaritalStatus == MaritalStatus.Married)
            {
                int riskPointsToAdd = 1;
                int riskPointsToRemove = 1;

                _riskPoints.AddToInsuranceLine(InsuranceLine.Life, riskPointsToAdd);
                _riskPoints.RemoveFromInsuranceLine(InsuranceLine.Disability, riskPointsToRemove);
            }

            return _riskPoints;
        }
    }
}
