using InsuranceAdvisor.Domain.Domain.Enums;

namespace InsuranceAdvisor.Domain.Responses
{
    //TODO: Risk profile
    public class CalculateInsuranceScoreResponse
    {
        public RiskCategory Auto { get; set; }
        public RiskCategory Disability { get; set; }
        public RiskCategory Home { get; set; }
        public RiskCategory Life { get; set; }
    }
}
