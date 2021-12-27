using InsuranceAdvisor.Domain.Domain.Enums;
using System.Text.Json.Serialization;

namespace InsuranceAdvisor.Domain.Responses
{
    public class AdviseInsurancePlanResponse
    {
        public AdviseInsurancePlanResponse(InsurancePlan auto, InsurancePlan disability, InsurancePlan home, InsurancePlan life)
        {
            Auto = auto;
            Disability = disability;
            Home = home;
            Life = life;
        }

        [JsonPropertyName("auto")]
        public InsurancePlan Auto { get; }

        [JsonPropertyName("disability")]
        public InsurancePlan Disability { get; }

        [JsonPropertyName("home")]
        public InsurancePlan Home { get; }

        [JsonPropertyName("life")]
        public InsurancePlan Life { get; }
    }
}
