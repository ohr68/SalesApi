using Ambev.DeveloperEvaluation.Application.Models.InputModels;
using Ambev.DeveloperEvaluation.Application.Models.InputModels.CreateSaleItem;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including . 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the Customer the sale was made to.
    /// </summary>
    public string Customer { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets or sets the branch that made the sale.
    /// </summary>
    public string Branch { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets or sets whether the sale was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
    
    /// <summary>
    /// Gets or sets the sale's items.
    /// Used as a navigation property on entity configuration.
    /// </summary>
    public ICollection<CreateSaleItemInputModel>? Items { get; set; }
    
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}