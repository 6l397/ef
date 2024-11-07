using FluentValidation;
using marketplace3.BusinessLogicLayer.DTO.Requests;

namespace marketplace3.BusinessLogicLayer.Validation
{
    public class ServicePricingRequestValidator : AbstractValidator<ServicePricingRequest>
    {
        public ServicePricingRequestValidator()
        {
            RuleFor(sp => sp.SellerId)
                .GreaterThan(0).WithMessage("SellerId must be greater than 0.");

            RuleFor(sp => sp.ServiceName)
                .NotEmpty().WithMessage("ServiceName is required.")
                .MaximumLength(100).WithMessage("ServiceName must not exceed 100 characters.");

            RuleFor(sp => sp.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            .ScalePrecision(2, 18).WithMessage("Price must have up to 18 digits in total, with 2 decimal places.");
        }
    }
}
