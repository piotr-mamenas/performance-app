using System;
using Core.Domain.Assets;
using FluentValidation;

namespace Core.Validation.Assets
{
    public class BondValidator : AbstractValidator<Bond>
    {
        public BondValidator()
        {
            RuleFor(b => b.FaceValue).NotEmpty().WithMessage("Bond Face Value must be specified");
            RuleFor(b => b.IssueDate).NotEmpty().WithMessage("Bond Issue Date must be specified");
            RuleFor(b => b.Coupon.Rate).NotEmpty().WithMessage("Bond Coupon Rate must be specified");
            RuleFor(b => b.Coupon.Amount).NotEmpty().WithMessage("Bond Coupon Amount must be specified");
            RuleFor(b => b.CurrencyId).NotEmpty().WithMessage("Bond Currency must be specified");
            RuleFor(b => b.MaturityDate).NotEmpty().WithMessage("Bond Maturity Date must be specified");

            RuleFor(b => b.FaceValue).GreaterThan(0).WithMessage("Bond Face Value cannot be negative");
            RuleFor(b => b.MaturityDate).GreaterThan(DateTime.Now).WithMessage("Maturity Date cannot be set in the past");
            RuleFor(b => b.Coupon.Amount).GreaterThanOrEqualTo(0).WithMessage("Bond Coupon Amount cannot be less than or equal 0");
            RuleFor(b => b.Coupon.Rate).GreaterThan(0).WithMessage("Bond Coupon Rate cannot be negative");
            RuleFor(b => b.Coupon.Rate).LessThan(1).WithMessage("Bond Coupon Rate cannot be more than 100%");
        }
    }
}
