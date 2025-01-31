using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Name { get; private set; } = string.Empty;
    
    /// <summary>
    /// Gets the description of the product.
    /// </summary>
    public string Description { get; private set; } = string.Empty;
    
    /// <summary>
    /// Gets the unit price of the item.
    /// </summary>
    public decimal UnitPrice { get; set; }
    
    /// <summary>
    /// Navigation property to define that a product can be
    /// in many sales items
    /// </summary>
    public virtual ICollection<SaleItem>? SalesItems { get; set; }
}