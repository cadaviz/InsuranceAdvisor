using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;

namespace InsuranceAdvisor.Domain.Domain.Rules
{
    internal abstract class RiskProfileRuleBase : IRule<RiskProfile, RiskScore>
    {
        protected readonly RiskScore _riskPoints;
        protected readonly RiskProfileRulesConfiguration _rulesConfiguration;

        protected RiskProfileRuleBase(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration)
        {
            _riskPoints = riskPoints;
            _rulesConfiguration = rulesConfiguration;
        }

        public abstract RiskScore Evaluate(RiskProfile riskProfile);
    }
}
