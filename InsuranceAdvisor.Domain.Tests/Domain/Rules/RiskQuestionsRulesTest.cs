﻿using InsuranceAdvisor.Domain.Domain;
using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Domain.RiskProfileRules.Rules;
using InsuranceAdvisor.Domain.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceAdvisor.Domain.Tests.Domain.Rules
{
    [TestClass]
    public class RiskQuestionsRulesTest
    {
        [TestMethod]
        public void AllQuestionsTrue()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithRiskQuestions(new bool[] { true, true, true });
            var rule = new RiskQuestionsRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(3, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(3, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void AllQuestionsFalse()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithRiskQuestions(new bool[] { false, false, false });
            var rule = new RiskQuestionsRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(0, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(0, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(0, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(0, result.Points[InsuranceLine.Life]);
        }

        [TestMethod]
        public void VariedAnswers()
        {
            // Arrange
            var riskProfile = RiskProfileBuilder.WithRiskQuestions(new bool[] { true, false, true });
            var rule = new RiskQuestionsRules(new RiskPoints());

            // Act
            var result = rule.Validate(riskProfile);

            // Assert
            Assert.AreEqual(4, result.Points.Count);
            Assert.AreEqual(2, result.Points[InsuranceLine.Auto]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Disability]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Home]);
            Assert.AreEqual(2, result.Points[InsuranceLine.Life]);
        }
    }
}
