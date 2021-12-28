using InsuranceAdvisor.Domain.Configurations;
using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class VehiculeRulesTest
    {
        [TestMethod]
        public void UserWithLastYearVehicle()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithVehicleProducedIn(DateTime.Now.Year);

            var riskPoints = new RiskScore();
            riskPoints.AddToAllInsuranceLines(2);

            var rule = new VehiculeRules(riskPoints, new RiskProfileRulesConfiguration());

            // Act
            var result = rule.Evaluate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(2, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void UserWithTenYearsOldVehicle()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithVehicleProducedIn(DateTime.Now.Year - 10);

            var riskPoints = new RiskScore();
            riskPoints.AddToAllInsuranceLines(2);

            var rule = new VehiculeRules(riskPoints, new RiskProfileRulesConfiguration());

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
