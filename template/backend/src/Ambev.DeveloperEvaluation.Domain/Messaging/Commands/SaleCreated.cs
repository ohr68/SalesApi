using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Messaging.Commands;

/// <summary>
/// Message model for SaleCreated event
/// </summary>
public class SaleCreated : Message
{
    /// <summary>
    ///  Gets the unique identifier of the sale.
    /// </summary>
    public Guid Id { get; private set; }
    
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
    /// </summary>
    public ICollection<SaleItem>? Items { get; set; }
}