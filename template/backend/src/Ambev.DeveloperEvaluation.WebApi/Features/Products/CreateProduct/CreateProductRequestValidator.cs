using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customer:  Required, must be between 5 and 100 characters
    /// - Branch: Required, must be between 5 and 100 characters
    /// - Items: Required, must have at least one
    /// </remarks>
    public CreateProductRequestValidator()
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
            .WithMessage("Price is required")
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");;

        RuleFor(p => p.Category)
            .NotEmpty()
            .WithMessage("Category is required")
            .Length(1, 150)
            .WithMessage("Category must be between 1 and 150 characters");
    }
}