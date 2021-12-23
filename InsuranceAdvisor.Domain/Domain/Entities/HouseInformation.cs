using InsuranceAdvisor.Domain.Domain.Enums;

namespace InsuranceAdvisor.Domain.Domain.Entities
{
    internal class HouseInformation
    {
        public HouseInformation(OwnershipStatus ownershipStatus)
        {
            OwnershipStatus = ownershipStatus;
        }

        public OwnershipStatus OwnershipStatus { get; }
    }
}
