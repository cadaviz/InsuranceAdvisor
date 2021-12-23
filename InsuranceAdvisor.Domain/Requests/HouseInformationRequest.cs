using InsuranceAdvisor.Domain.Domain.Enums;
using System.Text.Json.Serialization;

namespace InsuranceAdvisor.Domain.Requests
{
    public class HouseInformationRequest
    {
        [JsonPropertyName("ownership_status")]
        public OwnershipStatus OwnershipStatus { get; set; }
    }
}
