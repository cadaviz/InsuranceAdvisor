using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class MaritalStatusRulesTest
    {
        [TestMethod]
        public void UserIsMarried()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithMaritalStatus(MaritalStatus.Married);

            var riskScore = new RiskScore();
            riskScore.AddToAllInsuranceLines(2);

            var rule = new MaritalStatusRules(riskScore, new RiskProfileRulesConfiguration());

            // Act
            var result = rule.Evaluate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(1, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserIsSingle()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithMaritalStatus(MaritalStatus.Single);

            var riskScore = new RiskScore();
            riskScore.AddToAllInsuranceLines(2);

            var rule = new MaritalStatusRules(riskScore, new RiskProfileRulesConfiguration());

            // Act
            var result = rule.Evaluate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(2, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }
    }
}