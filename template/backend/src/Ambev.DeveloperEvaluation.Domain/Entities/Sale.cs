using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system with items.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the sale's number.
    /// Generated when sale is created and is unique.
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Gets the Date and time when the sale was made.
    /// Stored in Utc format to avoid timezone issues.
    /// </summary>
    public DateTime MadeOn { get; set; }
    
    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// Gets the Customer the sale was made to.
    /// </summary>
    public string Customer { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Gets the branch that made the sale.
    /// </summary>
    public string Branch { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets whether the sale was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
    
    /// <summary>
    /// Gets the sale's items.
    /// Used as a navigation property on entity configuration.
    /// </summary>
    public virtual ICollection<SaleItem>? Items { get; set; }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        MadeOn = DateTime.UtcNow;
    }
    
    /// <summary>
    /// Cancels the sale
    /// </summary>
    public void Cancel()
    {
        Cancelled = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    /// <summary>
    /// Performs validation of the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Customer length</list>
    /// <list type="bullet">Branch length</list>
    /// <list type="bullet">Items size</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}