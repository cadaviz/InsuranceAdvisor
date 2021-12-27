using InsuranceAdvisor.Domain.Domain.Entities;
using InsuranceAdvisor.Domain.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InsuranceAdvisor.Domain.Tests.Domain.Entities
{
    [TestClass]
    public class RiskPointsTest
    {
        private readonly RiskScore _riskPoints;
        public RiskPointsTest()
        {
            _riskPoints = new RiskScore();
        }

        [TestMethod]
        public void AddPointsToAllInsuranceLines()
        {
            // Arrange

            // Act
            _riskPoints.AddToAllInsuranceLines(3);

            // Assert
            Assert.AreEqual(3, _riskPoints.Points[InsuranceLine.Auto]);
            Assert.AreEqual(3, _riskPoints.Points[InsuranceLine.Disability]);
            Assert.AreEqual(3, _riskPoints.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, _riskPoints.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void RemovePointsFromAllInsuranceLines()
        {
            // Arrange
            _riskPoints.AddToAllInsuranceLines(4);

            // Act
            _riskPoints.RemoveFromAllInsuranceLines(2);

            // Assert
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void AddPointsToInsuranceLine()
        {
            // Arrange
            _riskPoints.AddToAllInsuranceLines(2);

            // Act
            _riskPoints.AddToInsuranceLine(InsuranceLine.Disability, 2);
            _riskPoints.AddToInsuranceLine(InsuranceLine.Life, 1);

            // Assert
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Auto]);
            Assert.AreEqual(4, _riskPoints.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, _riskPoints.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void RemovePointsFromInsuranceLine()
        {
            // Arrange
            _riskPoints.AddToAllInsuranceLines(4);

            // Act
            _riskPoints.RemoveFromInsuranceLine(InsuranceLine.Disability, 2);
            _riskPoints.RemoveFromInsuranceLine(InsuranceLine.Life, 1);

            // Assert
            Assert.AreEqual(4, _riskPoints.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, _riskPoints.Points[InsuranceLine.Disability]);
            Assert.AreEqual(4, _riskPoints.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, _riskPoints.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void TurnInsuranceLineIneligible()
        {
            // Arrange

            // Act
            _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            // Assert
            Assert.AreEqual(3, _riskPoints.Points.Count);
            Assert.IsFalse(_riskPoints.Points.ContainsKey(InsuranceLine.Disability));
        }

        [TestMethod]
        public void TurnInsuranceLineIneligibleTwice()
        {
            // Arrange

            // Act
            _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Disability);
            _riskPoints.TurnInsuranceLineIneligible(InsuranceLine.Disability);

            // Assert
            Assert.AreEqual(3, _riskPoints.Points.Count);
            Assert.IsFalse(_riskPoints.Points.ContainsKey(InsuranceLine.Disability));
        }

        [TestMethod]
        public void PointsCannotBeUpgradedOutsideClass()
        {
            // Arrange
            var initialValue = _riskPoints.Points[0];

            // Act
            _riskPoints.Points.ToDictionary(x => x.Key, x=> x.Value)[0] += 1;

            // Assert
            Assert.AreEqual(initialValue, _riskPoints.Points[0]);
        }
    }
}
