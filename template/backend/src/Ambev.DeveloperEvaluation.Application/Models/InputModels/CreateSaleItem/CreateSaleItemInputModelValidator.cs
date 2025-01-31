using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Models.InputModels.CreateSaleItem;

public class CreateSaleItemInputModelValidator : AbstractValidator<CreateSaleItemInputModel>
{
    public CreateSaleItemInputModelValidator()
    {
        RuleFor(si => si.Quantity)
            .NotEmpty()
            .WithMessage("At least one item is required.")
            .LessThan(20)
            .WithMessage(si => "Maximum limit: 20 items per product.");

        RuleFor(si => si.UnitPrice)
            .NotEmpty()
            .WithMessage("Item price is required.");
    }
}