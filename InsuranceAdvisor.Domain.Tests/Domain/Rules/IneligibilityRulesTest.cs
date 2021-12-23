using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class IneligibilityRulesTest
    {
        [TestMethod]
        public void EligibileToAllInsurances()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.DefaultProfile();
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Life));
        }

        [TestMethod]
        public void UserHasntVehicle()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithoutVehicle();
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(3, result.Points.Count);
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Life));
        }

        [TestMethod]
        public void UserHasntHouse()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithoutHouse();
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(3, result.Points.Count);
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Life));
        }

        [TestMethod]
        public void UserHasntIncome()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithoutIncome();
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(3, result.Points.Count);
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Life));
        }

        [TestMethod]
        public void UserHasntIncomeHomeAndVehicle()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithoutIncomeHomeAndVehicle();
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(1, result.Points.Count);
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Life));
        }

        [TestMethod]
        public void UserIsOverAgeLimitToInsurance()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithAge(61);
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(2, result.Points.Count);
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsFalse(result.Points.ContainsKey(InsuranceLine.Life));
        }

        [TestMethod]
        public void UserIsUnderAgeLimitToInsurance()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithAge(30);
            var rule = new IneligibilityRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Disability));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Home));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Auto));
            Assert.IsTrue(result.Points.ContainsKey(InsuranceLine.Life));
        }
    }
}
