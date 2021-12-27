using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Helpers;

namespace InsuranceAdvisor.Domain.Domain.Entities
{
    internal class InsurancePlanAdvise
    {
        private readonly Dictionary<InsuranceLine, InsurancePlan> _plan = new();
        public IReadOnlyDictionary<InsuranceLine, InsurancePlan> Plan => _plan;

        public InsurancePlanAdvise(RiskScore riskScore)
        {
            EvaluateRiskScore(riskScore);
        }

        private void EvaluateRiskScore(RiskScore riskScore)
        {
            foreach (var insuranceLine in EnumHelper.GetEnumList<InsuranceLine>())
            {
                InsurancePlan insurancePlan;

                if (!riskScore.IsEligible(insuranceLine))
                    insurancePlan = InsurancePlan.Ineligible;
                else if (riskScore.Points[insuranceLine] <= 0)
                    insurancePlan = InsurancePlan.Economic;
                else if (riskScore.Points[insuranceLine] <= 2)
                    insurancePlan = InsurancePlan.Regular;
                else
                    insurancePlan = InsurancePlan.Responsible;

                _plan.Add(insuranceLine, insurancePlan);
            }
        }
    }
}
