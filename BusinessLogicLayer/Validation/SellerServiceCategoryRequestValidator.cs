using FluentValidation;
using marketplace3.BusinessLogicLayer.DTO.Requests;

namespace marketplace3.BusinessLogicLayer.Validation
{
    public class SellerServiceCategoryRequestValidator : AbstractValidator<SellerServiceCategoryRequest>
    {
        public SellerServiceCategoryRequestValidator()
        {
            RuleFor(ssc => ssc.SellerId)
                .GreaterThan(0).WithMessage("SellerId must be greater than 0.");

            RuleFor(ssc => ssc.ServiceCategoryId)
                .GreaterThan(0).WithMessage("ServiceCategoryId must be greater than 0.");
        }
    }
}
