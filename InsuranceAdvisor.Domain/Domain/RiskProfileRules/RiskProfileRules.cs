using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;

namespace InsuranceAdvisor.Domain.Domain.Rules
{
    internal class RiskProfileRules
    {
        private readonly List<IRule<RiskProfile, RiskPoints>> _rules;
        private readonly RiskPoints _points;

        public RiskProfileRules()
        {
            _points = new RiskPoints();

            _rules = new List<IRule<RiskProfile, RiskPoints>>
            {
                new IneligibilityRules(_points),
                new RiskQuestionsRules(_points),
                new AgeRules(_points),
                new IncomeRules(_points),
                new HouseRules(_points),
                new DependentsRules(_points),
                new MaritalStatusRules(_points),
                new VehiculeRules(_points),
            };
        }

        public RiskPoints Validate(RiskProfile riskProfile)
        {
            _rules.ForEach(rule => rule.Validate(riskProfile));

            return _points;
        }
    }
}
