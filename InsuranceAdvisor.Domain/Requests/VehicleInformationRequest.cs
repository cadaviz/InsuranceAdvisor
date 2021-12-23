using System.Text.Json.Serialization;

namespace InsuranceAdvisor.Domain.Requests
{
    public class VehicleInformationRequest
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
