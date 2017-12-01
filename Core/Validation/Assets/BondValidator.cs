using System;
using Core.Domain.Assets;
using FluentValidation;

namespace Core.Validation.Assets
{
    public class BondValidator : AbstractValidator<Bond>
    {
        public BondValidator()
        {
            RuleFor(b => b.FaceValue).LessThan(0).WithMessage("Bond Face Value cannot be negative");
            RuleFor(b => b.MaturityDate).LessThan(DateTime.Now).WithMessage("Maturity cannot be set in the past");
            RuleFor(b => b.Coupon.Amount).LessThanOrEqualTo(0).WithMessage("Bond Coupon Amount cannot be less than or equal 0");
            RuleFor(b => b.Coupon.Rate).LessThan(0).WithMessage("Bond Coupon rate cannot be negative");
            RuleFor(b => b.Coupon.Rate).GreaterThan(1).WithMessage("Bond Coupon rate cannot be more than 100%");
        }
    }
}
