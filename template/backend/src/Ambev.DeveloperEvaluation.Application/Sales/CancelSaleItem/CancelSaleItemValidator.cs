using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleItemCommand
/// </summary>
public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleItemCommand
    /// </summary>
    public CancelSaleItemValidator()
    {
        RuleFor(c => c.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required");
        
        RuleFor(c => c.ItemId)
            .NotEmpty()
            .WithMessage("Item ID is required");
    }
}