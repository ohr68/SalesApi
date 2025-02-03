﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Validator for CancelSaleCommand
/// </summary>
public class CancelSaleValidator : AbstractValidator<CancelSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleCommand
    /// </summary>
    public CancelSaleValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}