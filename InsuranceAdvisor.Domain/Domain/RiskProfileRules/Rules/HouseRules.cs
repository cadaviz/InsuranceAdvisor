using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.Rules;

namespace InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules
{
    internal sealed class HouseRules : RiskProfileRuleBase
    {
        public HouseRules(RiskPoints riskPoints) : base(riskPoints) { }

        public override RiskPoints Validate(RiskProfile riskProfile)
        {
            if (riskProfile.HasHouse && riskProfile.House.OwnershipStatus == OwnershipStatus.Mortgaged)
            {
                int riskPointsToAdd = 1;

                _riskPoints.AddToInsuranceLine(InsuranceLine.Home, riskPointsToAdd);
                _riskPoints.AddToInsuranceLine(InsuranceLine.Disability, riskPointsToAdd);
            }

            return _riskPoints;
        }
    }
}
