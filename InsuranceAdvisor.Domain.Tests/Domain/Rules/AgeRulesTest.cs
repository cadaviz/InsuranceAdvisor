using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class AgeRulesTest
    {
        [TestMethod]
        public void UserWithoutLowRiskAge()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithAge(25);

            var riskPoints = new RiskPoints();
            riskPoints.AddToAllInsuranceLines(2);

            var rule = new AgeRules(riskPoints);

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(0, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(0, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(0, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(0, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserWithoutMediumRiskAge()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithAge(35);

            var riskPoints = new RiskPoints();
            riskPoints.AddToAllInsuranceLines(2);

            var rule = new AgeRules(riskPoints);

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(1, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(1, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(1, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(1, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserWithoutNoRiskAge()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithAge(45);

            var riskPoints = new RiskPoints();
            riskPoints.AddToAllInsuranceLines(2);

            var rule = new AgeRules(riskPoints);

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(2, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }
    }
}
