using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class IncomeRulesTest
    {
        [TestMethod]
        public void UserWithoutRiskIncome()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithIncome(500000);

            var riskPoints = new RiskPoints();
            riskPoints.AddToAllInsuranceLines(5);

            var rule = new IncomeRules(riskPoints);

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(4, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(4, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(4, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(4, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserWithRiskIncome()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithIncome(10000);

            var riskPoints = new RiskPoints();
            riskPoints.AddToAllInsuranceLines(5);

            var rule = new IncomeRules(riskPoints);

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(5, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(5, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(5, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(5, result.Points[InsuranceLine.Life]);
        }
    }
}
