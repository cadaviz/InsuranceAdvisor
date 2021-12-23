using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class RiskQuestionsRules : RiskProfileRuleBase
    {
        internal RiskQuestionsRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
        {
            var baseScore = riskProfile.RiskQuestions.Count(x => x);
            _riskPoints.AddToAllInsuranceLines(baseScore);

            return _riskPoints;
        }
    }
}
