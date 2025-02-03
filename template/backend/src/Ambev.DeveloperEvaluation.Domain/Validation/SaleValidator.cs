using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(s => s.Customer)
            .NotEmpty()
            .WithMessage("Customer is required.")
            .Length(5, 100)
            .WithMessage("Customer name must be between 5 and 100 characters.");
        
        RuleFor(s => s.Branch)
            .NotEmpty()
            .WithMessage("Branch is required.")
            .Length(5, 100)
            .WithMessage("Branch name must be between 5 and 100 characters.");
        
        RuleFor(s => s.Items)
            .NotEmpty()
            .WithMessage("Sale must have at least one item.");
    }
}