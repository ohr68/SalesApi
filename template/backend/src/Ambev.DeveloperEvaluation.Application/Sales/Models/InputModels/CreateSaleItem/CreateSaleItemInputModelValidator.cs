using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Models.InputModels.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemInputModel
/// </summary>
public class CreateSaleItemInputModelValidator : AbstractValidator<CreateSaleItemInputModel>
{
    /// <summary>
    /// Initializes validation rules for CreateSaleItemInputModel
    /// </summary>
    public CreateSaleItemInputModelValidator()
    {
        RuleFor(si => si.Quantity)
            .NotEmpty()
            .WithMessage("At least one item is required")
            .LessThan(20)
            .WithMessage(si => "Maximum limit: 20 items per product");

        RuleFor(si => si.UnitPrice)
            .NotEmpty()
            .WithMessage("Item price is required");
        
        RuleFor(si => si.ProductId)
            .NotEmpty()
            .WithMessage("Product id is required");
    }
}