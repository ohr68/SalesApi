using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customer:  Required, must be between 5 and 100 characters
    /// - Branch: Required, must be between 5 and 100 characters
    /// - Items: Required, must have at least one
    /// </remarks>
    public CreateSaleCommandValidator()
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