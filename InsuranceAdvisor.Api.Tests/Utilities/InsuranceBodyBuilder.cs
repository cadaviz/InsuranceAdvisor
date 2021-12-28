using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAdvisor.Api.Tests.Utilities
{
    internal static class InsuranceBodyBuilder
    {
        public static object Default()
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutAge()
        {
            return new
            {
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithAge(int age)
        {
            return new
            {
                age = age,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutDependents()
        {
            return new
            {
                age = 35,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithDependents(int dependents)
        {
            return new
            {
                age = 35,
                dependents = dependents,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutHouse()
        {
            return new
            {
                age = 35,
                dependents = 2,
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithHouseOwnershipStatus(string ownershipStatus)
        {
            return new
            {
                age = 35,
                dependents = 2,
                house = new { ownership_status = ownershipStatus },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutIncome()
        {
            return new
            {
                age = 35,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithIncome(decimal income)
        {
            return new
            {
                age = 35,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = income,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutMaritalStatus()
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithMaritalStatus(string maritalStatus)
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = maritalStatus,
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutRiskQuestions()
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                vehicle = new { year = 2018 },
            };
        }

        public static object WithRiskQuestions(IList<int> riskQuestions)
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = riskQuestions,
                vehicle = new { year = 2018 },
            };
        }

        public static object WithoutVehicle()
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
            };
        }

        public static object WithVehicle(int vehicleYear)
        {
            return new
            {
                age = 36,
                dependents = 2,
                house = new { ownership_status = "mortgaged" },
                income = 15000,
                marital_status = "married",
                risk_questions = new List<int> { 0, 1, 0 },
                vehicle = new { year = vehicleYear },
            };
        }
    }
}
