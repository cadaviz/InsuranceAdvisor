using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using System;

namespace InsuranceAdvisor.Domain.Tests.Utilities
{
    internal static class RiskProfileBuilder
    {
        public static RiskProfile DefaultProfile()
        {
            return new RiskProfile(age: 35,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: 300000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithAge(int age)
        {
            return new RiskProfile(age: age,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: 10000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithDependents(int dependents)
        {
            return new RiskProfile(age: 35,
                                   dependents: dependents,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: 10000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithHouse(OwnershipStatus ownershipStatus)
        {
            return new RiskProfile(age: 25,
                                   dependents: 1,
                                   house: new HouseInformation(ownershipStatus),
                                   income: 10000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithoutHouse()
        {
            return new RiskProfile(age: 35,
                                   dependents: 1,
                                   house: null,
                                   income: 10000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithIncome(decimal income)
        {
            return new RiskProfile(age: 25,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: income,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithoutIncome()
        {
            return new RiskProfile(age: 35,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: default,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithMaritalStatus(MaritalStatus maritalStatus)
        {
            return new RiskProfile(age: 25,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: 10000m,
                                   maritalStatus: maritalStatus,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(DateTime.Now.Year));
        }

        public static RiskProfile WithRiskQuestions(bool[] questions)
        {
            return new RiskProfile(age: default,
                                   dependents: default,
                                   house: default,
                                   income: default,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: questions,
                                   vehicle: default);
        }

        public static RiskProfile WithVehicleProducedIn(int year)
        {
            return new RiskProfile(age: 35,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: 10000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: new VehicleInformation(year));
        }

        public static RiskProfile WithoutVehicle()
        {
            return new RiskProfile(age: 35,
                                   dependents: 1,
                                   house: new HouseInformation(OwnershipStatus.Owned),
                                   income: 10000m,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: null);
        }

        public static RiskProfile WithoutIncomeHomeAndVehicle()
        {
            return new RiskProfile(age: default,
                                   dependents: default,
                                   house: default,
                                   income: default,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new bool[] { false, false, false },
                                   vehicle: default);
        }
    }
}
