﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Validator for GetProductCommand
/// </summary>
public class GetProductValidator : AbstractValidator<GetProductCommand>
{ 
    /// <summary>
    /// Initializes validation rules for GetProductCommand
    /// </summary>
    public GetProductValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Product id is required");
    }
}