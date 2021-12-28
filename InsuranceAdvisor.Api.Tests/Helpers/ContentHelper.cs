using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace InsuranceAdvisor.Api.Tests.Helpers
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new(JsonSerializer.Serialize(obj), Encoding.Default, "application/json");
    }
}
