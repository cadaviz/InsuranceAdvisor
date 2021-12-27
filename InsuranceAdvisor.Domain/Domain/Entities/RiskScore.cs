using InsuranceAdvisor.Domain.Domain.Enums;
using InsuranceAdvisor.Domain.Helpers;

namespace InsuranceAdvisor.Domain.Domain.Entities
{
    internal class RiskScore
    {
        private readonly Dictionary<InsuranceLine, int> _points;
        public IReadOnlyDictionary<InsuranceLine, int> Points => _points;

        public RiskScore()
        {
            _points = EnumHelper.GetEnumList<InsuranceLine>().ToDictionary(x => x, y => default(int));
        }

        public void AddToAllInsuranceLines(int quantity)
        {
            UpdateAllInsuranceLinesQuantity(quantity);
        }

        public void RemoveFromAllInsuranceLines(int quantity)
        {
            UpdateAllInsuranceLinesQuantity(quantity * -1);
        }

        public void AddToInsuranceLine(InsuranceLine insuranceLine, int quantity)
        {
            if (!IsEligible(insuranceLine))
                return;

            _points[insuranceLine] += quantity;
        }

        public void RemoveFromInsuranceLine(InsuranceLine insuranceLine, int quantity)
        {
            if (!IsEligible(insuranceLine))
                return;

            _points[insuranceLine] -= quantity;
        }

        public void TurnInsuranceLineIneligible(InsuranceLine insuranceLine)
        {
            _points.Remove(insuranceLine);
        }

        public bool IsEligible(InsuranceLine insuranceLine)
        {
            return _points.ContainsKey(insuranceLine);
        }

        private void UpdateAllInsuranceLinesQuantity(int quantity)
        {
            foreach (var insuranceLineKey in _points.Keys)
            {
                _points[insuranceLineKey] += quantity;
            }
        }
    }
}
