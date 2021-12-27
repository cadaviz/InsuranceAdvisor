using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class RiskQuestionsRules : RiskProfileRuleBase
    {
        internal RiskQuestionsRules(RiskScore riskPoints, RiskProfileRulesConfiguration rulesConfiguration) : base(riskPoints, rulesConfiguration) { }

        public override RiskScore Evaluate(RiskProfile riskProfile)
        {
            var baseScore = riskProfile.RiskQuestions.Count(x => x);
            _riskPoints.AddToAllInsuranceLines(baseScore);

            return _riskPoints;
        }
    }
}
