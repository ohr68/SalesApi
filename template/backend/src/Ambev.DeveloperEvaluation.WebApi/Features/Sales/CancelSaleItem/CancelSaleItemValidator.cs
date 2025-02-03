using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleItemRequest
/// </summary>
public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemRequest>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleItemRequest
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