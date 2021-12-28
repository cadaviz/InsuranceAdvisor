using InsuranceAdvisor.Domain.Domain.Enums;
using System.Text.Json.Serialization;

namespace InsuranceAdvisor.Domain.Requests
{
    public class AdviseInsurancePlanRequest 
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("dependents")]
        public int Dependents { get; set; }

        [JsonPropertyName("house")]
        public HouseInformationRequest? House { get; set; }

        [JsonPropertyName("income")]
        public decimal Income { get; set; }

        [JsonPropertyName("marital_status")]
        public MaritalStatus? MaritalStatus { get; set; }

        [JsonPropertyName("risk_questions")]
        public int[] RiskQuestions { get; set; } = Array.Empty<int>();

        [JsonPropertyName("vehicle")]
        public VehicleInformationRequest? Vehicle { get; set; }

    }
}
