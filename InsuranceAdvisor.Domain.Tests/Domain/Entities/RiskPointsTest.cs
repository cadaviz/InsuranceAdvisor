using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InsuranceAdvisor.Domain.Tests.Domain.Entities
{
    [TestClass]
    public class RiskPointsTest
    {
        private readonly RiskScore _riskScore;
        public RiskPointsTest()
        {
            _riskScore = new RiskScore();
        }

        [TestMethod]
        public void AddPointsToAllInsuranceLines()
        {
            // Arrange

            // Act
            _riskScore.AddToAllInsuranceLines(3);

            // Assert
            Assert.AreEqual(3, _riskScore.Points[InsuranceLine.Auto]);
            Assert.AreEqual(3, _riskScore.Points[InsuranceLine.Disability]);
            Assert.AreEqual(3, _riskScore.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, _riskScore.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void RemovePointsFromAllInsuranceLines()
        {
            // Arrange
            _riskScore.AddToAllInsuranceLines(4);

            // Act
            _riskScore.RemoveFromAllInsuranceLines(2);

            // Assert
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void AddPointsToInsuranceLine()
        {
            // Arrange
            _riskScore.AddToAllInsuranceLines(2);

            // Act
            _riskScore.AddToInsuranceLine(InsuranceLine.Disability, 2);
            _riskScore.AddToInsuranceLine(InsuranceLine.Life, 1);

            // Assert
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Auto]);
            Assert.AreEqual(4, _riskScore.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, _riskScore.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void RemovePointsFromInsuranceLine()
        {
            // Arrange
            _riskScore.AddToAllInsuranceLines(4);

            // Act
            _riskScore.RemoveFromInsuranceLine(InsuranceLine.Disability, 2);
            _riskScore.RemoveFromInsuranceLine(InsuranceLine.Life, 1);

            // Assert
            Assert.AreEqual(4, _riskScore.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, _riskScore.Points[InsuranceLine.Disability]);
            Assert.AreEqual(4, _riskScore.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, _riskScore.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void TurnInsuranceLineIneligible()
        {
            // Arrange

            // Act
            _riskScore.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            // Assert
            Assert.AreEqual(3, _riskScore.Points.Count);
            Assert.IsFalse(_riskScore.Points.ContainsKey(InsuranceLine.Disability));
        }

        [TestMethod]
        public void TurnInsuranceLineIneligibleTwice()
        {
            // Arrange

            // Act
            _riskScore.TurnInsuranceLineIneligible(InsuranceLine.Disability);
            _riskScore.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            // Assert
            Assert.AreEqual(3, _riskScore.Points.Count);
            Assert.IsFalse(_riskScore.Points.ContainsKey(InsuranceLine.Disability));
        }

        [TestMethod]
        public void PointsCannotBeUpgradedOutsideClass()
        {
            // Arrange
            var initialValue = _riskScore.Points[0];

            // Act
            _riskScore.Points.ToDictionary(x => x.Key, x=> x.Value)[0] += 1;

            // Assert
            Assert.AreEqual(initialValue, _riskScore.Points[0]);
        }
    }
}
