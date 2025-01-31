using Ambev.DeveloperEvaluation.Domain.Common;

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
}