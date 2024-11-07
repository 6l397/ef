using FluentValidation;
using marketplace3.BusinessLogicLayer.DTO.Requests;

namespace marketplace3.BusinessLogicLayer.Validation
{
    public class SellerRequestValidator : AbstractValidator<SellerRequest>
    {
        public SellerRequestValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            
            RuleFor(s => s.Description)
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

            
            RuleFor(s => s.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{3}-\d{3}-\d{4}$").WithMessage("Phone number must be in the format XXX-XXX-XXXX.")
                .MaximumLength(20).WithMessage("Phone number cannot be longer than 20 characters.");

            
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot be longer than 100 characters.");

            
            RuleFor(s => s.LocationId)
                .NotEmpty().WithMessage("Location is required.")
                .GreaterThan(0).WithMessage("Invalid Location ID.");
        }
    }
}
