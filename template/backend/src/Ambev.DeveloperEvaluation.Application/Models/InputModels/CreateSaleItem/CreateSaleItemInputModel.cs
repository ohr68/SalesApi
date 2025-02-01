using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Models.InputModels.CreateSaleItem;

/// <summary>
/// InputModel for creating a new sale's item.
/// </summary>
/// <remarks>
/// This model is used to capture the required data for creating a sale's item, 
/// including . 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleItemInputModel
{
    /// <summary>
    /// Gets the quantity sold of the item.
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Gets the id of the product which the item represents.
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Gets whether the item was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
    
    /// <summary>
    /// Gets the unit price of the product which the item represents.
    /// </summary>
    public decimal UnitPrice { get; set; }
    
    
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleItemInputModelValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}