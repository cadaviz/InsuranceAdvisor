using FluentValidation;
using InsuranceAdvisor.Domain.Configurations;

namespace InsuranceAdvisor.Domain.Requests.Validators
{
    internal class VehicleInformationRequestValidator : AbstractValidator<VehicleInformationRequest?>
    {
        public VehicleInformationRequestValidator(AdviseInsurancePlanRequestValidationConfiguration insuranceRequestLimits)
        {
            RuleFor(x => x.Year)
                .GreaterThan(insuranceRequestLimits.VehicleMinimumYear).When(x => x is not null).WithMessage($"The vehicle product year must be greter than {insuranceRequestLimits.VehicleMinimumYear}.")
                .LessThanOrEqualTo(insuranceRequestLimits.VehicleMaximumYear).When(x => x is not null).WithMessage($"The vehicle product year must be be lower than or equal to {insuranceRequestLimits.VehicleMaximumYear}.");
        }
    }
}
