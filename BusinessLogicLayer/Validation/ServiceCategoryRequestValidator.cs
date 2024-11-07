using FluentValidation;
using marketplace3.BusinessLogicLayer.DTO.Requests;

namespace marketplace3.BusinessLogicLayer.Validation
{
    public class ServiceCategoryRequestValidator : AbstractValidator<ServiceCategoryRequest>
    {
        public ServiceCategoryRequestValidator()
        {
            RuleFor(sc => sc.CategoryName)
                .NotEmpty().WithMessage("CategoryName is required.")
                .MaximumLength(100).WithMessage("CategoryName must not exceed 100 characters.");
        }
    }
}
