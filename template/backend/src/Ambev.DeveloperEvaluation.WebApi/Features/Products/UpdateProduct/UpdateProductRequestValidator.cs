using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductRequest
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// Initializes validation rules for UpdateProductRequest
    /// </summary>
    public UpdateProductRequestValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .Length(1, 100)
            .WithMessage("Title must be between 1 and 100 characters");
        
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .Length(10, 300)
            .WithMessage("Description must be between 10 and 300 characters");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage("Price is required");

        RuleFor(p => p.Category)
            .NotEmpty()
            .WithMessage("Category is required")
            .Length(1, 150)
            .WithMessage("Category must be between 1 and 150 characters");
    }
}