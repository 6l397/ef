using FluentValidation;
using marketplace3.BusinessLogicLayer.DTO.Requests;

namespace marketplace3.BusinessLogicLayer.Validation
{
    public class LocationRequestValidator : AbstractValidator<LocationRequest>
    {
        public LocationRequestValidator()
        {
            RuleFor(location => location.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            RuleFor(location => location.StreetAddress)
                .NotEmpty().WithMessage("Street Address is required.")
                .MaximumLength(200).WithMessage("Street Address cannot exceed 200 characters.");
        }
    }
}
