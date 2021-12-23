namespace InsuranceAdvisor.Domain.Domain.Entities
{
    internal class VehicleInformation
    {
        public VehicleInformation(int year)
        {
            Year = year;
        }

        public int Year { get; }
    }
}
