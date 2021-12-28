namespace InsuranceAdvisor.Domain.Configurations
{
    internal class AdviseInsurancePlanRequestValidationConfiguration
    {
        public static string Id => "AdviseInsurancePlanRequestValidationConfiguration";

        public int MinimumAge { get; set; } = default;
        public int MaximumAge { get; set; } = 120;

        public int MinimumDependents { get; set; } = default;
        public int MaximumDependents { get; set; } = 99;

        public decimal MinimumIncome { get; set; } = default;

        public int LengthOfRiskQuestions { get; set; } = 3;

        public int VehicleMinimumYear { get; set; } = 1900;
        public int VehicleMaximumYear { get; set; } = DateTime.Now.Year;
    }
}
