using FluentValidation;
using InsuranceAdvisor.Domain.Configurations;

namespace InsuranceAdvisor.Domain.Requests.Validators
{
    internal class HouseInformationRequestValidator : AbstractValidator<HouseInformationRequest?>
    {
        public HouseInformationRequestValidator()
        {
            RuleFor(x => x.OwnershipStatus)
                .IsInEnum().When(x => x is not null).WithMessage("Invalid value for ownership status.")
                .NotNull().When(x => x is not null).WithMessage("Ownership status cannot be null.");
        }
    }
}
