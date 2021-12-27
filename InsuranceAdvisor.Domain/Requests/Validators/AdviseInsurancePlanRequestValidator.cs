using FluentValidation;
using InsuranceAdvisor.Domain.Configurations;
using Microsoft.Extensions.Options;

namespace InsuranceAdvisor.Domain.Requests.Validators
{
    internal class AdviseInsurancePlanRequestValidator : AbstractValidator<AdviseInsurancePlanRequest>
    {
        public AdviseInsurancePlanRequestValidator(IOptions<AdviseInsurancePlanRequestValidationConfiguration> insuranceRequestLimitsOptions)
        {
            var insuranceRequestLimits = insuranceRequestLimitsOptions.Value;

            RuleFor(x => x.Age)
                .GreaterThan(insuranceRequestLimits.MinimumAge).WithMessage($"The age must be greater than {insuranceRequestLimits.MinimumAge}.")
                .LessThanOrEqualTo(insuranceRequestLimits.MaximumAge).WithMessage($"The age must be lower than or equal to {insuranceRequestLimits.MaximumAge}.");

            RuleFor(x => x.Dependents)
                .GreaterThanOrEqualTo(insuranceRequestLimits.MinimumDependents).WithMessage($"The dependents number must be greater than or equal to {insuranceRequestLimits.MinimumDependents}.")
                .LessThanOrEqualTo(insuranceRequestLimits.MaximumDependents).WithMessage($"The dependents number must be lower than or equal to {insuranceRequestLimits.MaximumDependents}.");

            RuleFor(x => x.Income)
                .GreaterThanOrEqualTo(insuranceRequestLimits.MinimumIncome).WithMessage($"The income value must be greater than or equal to {insuranceRequestLimits.MinimumIncome.ToString("{0:C}")}.");

            RuleFor(x => x.RiskQuestions)
                .NotNull().WithMessage("Risk questions cannot be null.")
                .Must(riskQuestions => riskQuestions.Length == insuranceRequestLimits.LengthOfRiskQuestions).WithMessage($"There need to be {insuranceRequestLimits.LengthOfRiskQuestions} answers to risk questions.");

            RuleFor(x => x.Vehicle)
                .SetValidator(new VehicleInformationRequestValidator(insuranceRequestLimits));

            RuleFor(x => x.House)
               .SetValidator(new HouseInformationRequestValidator());

            RuleFor(x => x.MaritalStatus)
                .IsInEnum().WithMessage("Invalid value for marital status.")
                .NotNull().WithMessage("Marital status cannot be null.");
        }
    }
}
