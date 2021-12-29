using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Entities
{
    [TestClass]
    public class InsurancePlanAdviseTest
    {
        private readonly RiskScore _riskScore;

        public InsurancePlanAdviseTest()
        {
            _riskScore = new RiskScore();
        }

        [TestMethod]
        public void IneligibleForDisability()
        {
            // Arrange
            _riskScore.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            // Act
            var insurancePlanAdvise = new InsurancePlanAdvise(_riskScore);

            // Assert
            Assert.AreEqual(InsurancePlan.Ineligible, insurancePlanAdvise.Plan[InsuranceLine.Disability]);
        }

        [TestMethod]
        public void EconomicForLife()
        {
            // Arrange

            // Act
            var insurancePlanAdvise = new InsurancePlanAdvise(_riskScore);

            // Assert
            Assert.AreEqual(InsurancePlan.Economic, insurancePlanAdvise.Plan[InsuranceLine.Life]);
        }

        [TestMethod]
        public void RegularForLife()
        {
            // Arrange
            _riskScore.AddToInsuranceLine(InsuranceLine.Life, 2);

            // Act
            var insurancePlanAdvise = new InsurancePlanAdvise(_riskScore);

            // Assert
            Assert.AreEqual(InsurancePlan.Regular, insurancePlanAdvise.Plan[InsuranceLine.Life]);
        }

        [TestMethod]
        public void ResponsibleForLife()
        {
            // Arrange
            _riskScore.AddToInsuranceLine(InsuranceLine.Life, 4);

            // Act
            var insurancePlanAdvise = new InsurancePlanAdvise(_riskScore);

            // Assert
            Assert.AreEqual(InsurancePlan.Responsible, insurancePlanAdvise.Plan[InsuranceLine.Life]);
        }
    }
}
