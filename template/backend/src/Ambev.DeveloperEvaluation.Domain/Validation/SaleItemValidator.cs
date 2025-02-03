using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(si => si.Quantity)
            .NotEmpty()
            .WithMessage("At least one item is required")
            .LessThan(20)
            .WithMessage(si => "Maximum limit: 20 items per product");
    }
}