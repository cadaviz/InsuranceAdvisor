using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;

namespace InsuranceAdvisor.Domain.Domain.Rules
{
    internal class RiskProfileRules
    {
        private readonly List<IRule<RiskProfile, RiskScore>> _rules;
        private readonly RiskScore _points;

        public RiskProfileRules(RiskProfileRulesConfiguration rulesConfiguration)
        {
            _points = new RiskScore();

            _rules = new List<IRule<RiskProfile, RiskScore>>
            {
                new IneligibilityRules(_points, rulesConfiguration),
                new RiskQuestionsRules(_points, rulesConfiguration),
                new AgeRules(_points, rulesConfiguration),
                new IncomeRules(_points, rulesConfiguration),
                new HouseRules(_points, rulesConfiguration),
                new DependentsRules(_points, rulesConfiguration),
                new MaritalStatusRules(_points, rulesConfiguration),
                new VehiculeRules(_points, rulesConfiguration),
            };
        }

        public RiskScore Evaluate(RiskProfile riskProfile)
        {
            _rules.ForEach(rule => rule.Evaluate(riskProfile));

            return _points;
        }
    }
}
