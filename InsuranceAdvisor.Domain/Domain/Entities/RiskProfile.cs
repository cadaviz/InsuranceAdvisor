using InsuranceAdvisor.Domain.Domain.Enums;

namespace InsuranceAdvisor.Domain.Domain.Entities
{
    internal class RiskProfile
    {
        public RiskProfile(int age, int dependents, HouseInformation? house, decimal income, MaritalStatus maritalStatus, bool[] riskQuestions, VehicleInformation? vehicle)
        {
            Age = age;
            Dependents = dependents;
            House = house;
            Income = income;
            MaritalStatus = maritalStatus;
            RiskQuestions = riskQuestions;
            Vehicle = vehicle;
        }

        public int Age { get; }
        public int Dependents { get; }
        public HouseInformation? House { get; }
        public decimal Income { get; }
        public MaritalStatus MaritalStatus { get; }
        public bool[] RiskQuestions { get; }
        public VehicleInformation? Vehicle { get; }

        public bool HasDependents => Dependents > 0;
        public bool HasIncome => Income > decimal.Zero;
        public bool HasHouse => House is not null;
        public bool HasVehicle => Vehicle is not null;
    }
}
