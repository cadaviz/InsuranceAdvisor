using InsuranceAdvisor.Domain.Domain.Enums;

namespace InsuranceAdvisor.Domain.Domain
{
    internal class RiskPoints
    {
        private readonly Dictionary<InsuranceLine, int> _points;

        public IReadOnlyDictionary<InsuranceLine, int> Points => _points;

        public RiskPoints()
        {
            _points = new Dictionary<InsuranceLine, int>();

            _points.Add(InsuranceLine.Auto, default);
            _points.Add(InsuranceLine.Disability, default);
            _points.Add(InsuranceLine.Home, default);
            _points.Add(InsuranceLine.Life, default);
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
            _points[insuranceLine] += quantity;
        }

        public void RemoveFromInsuranceLine(InsuranceLine insuranceLine, int quantity)
        {
            _points[insuranceLine] -= quantity;
        }

        public void TurnInsuranceLineIneligible(InsuranceLine insuranceLine)
        {
            _points.Remove(insuranceLine);
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
