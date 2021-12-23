using InsuranceAdvisor.Domain.Domain.Entities;

namespace InsuranceAdvisor.Domain.Domain.Rules
{
    internal abstract class RiskProfileRuleBase : IRule<RiskProfile, RiskPoints>
    {
        protected readonly RiskPoints _riskPoints;

        protected RiskProfileRuleBase(RiskPoints riskPoints)
        {
            _riskPoints = riskPoints;
        }

        public abstract RiskPoints Validate(RiskProfile riskProfile);
    }
}
