namespace InsuranceAdvisor.Domain.Configurations
{
    internal class RiskProfileRulesConfiguration
    {
        public static string Id => "RiskProfileRulesConfiguration";

        public int AgeLimitForLifeInsurance { get; set; } = 60;
        public int AgeLimitForDisabilityInsurance { get; set; } = 60;
        public int LowRiskLevelAge { get; set; } = 30;
        public int MediumRiskLevelAge { get; set; } = 40;
        public decimal LowRiskIncome { get; set; } = 200000m;
        public int HighRiskYearsForVehicle { get; set; } = 5;
    }
}
