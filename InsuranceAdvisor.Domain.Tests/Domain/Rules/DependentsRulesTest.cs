using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class DependentsRulesTest
    {
        [TestMethod]
        public void UserWithoutDependents()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithDependents(0);

            var riskScore = new RiskScore();
            riskScore.AddToAllInsuranceLines(2);

            var rule = new DependentsRules(riskScore, new RiskProfileRulesConfiguration());

            // Act
            var result = rule.Evaluate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(2, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserWithTwoDependents()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithDependents(2);

            var riskScore = new RiskScore();
            riskScore.AddToAllInsuranceLines(2);

            var rule = new DependentsRules(riskScore, new RiskProfileRulesConfiguration());

            // Act
            var result = rule.Evaluate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(3, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserWithFiveDependents()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithDependents(5);

            var riskScore = new RiskScore();
            riskScore.AddToAllInsuranceLines(2);

            var rule = new DependentsRules(riskScore, new RiskProfileRulesConfiguration());

            // Act
            var result = rule.Evaluate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(3, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }
    }
}
