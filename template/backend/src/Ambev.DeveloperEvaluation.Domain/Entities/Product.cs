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
    public string Title { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the description of the product.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the category of the product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the Image of the product.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the product's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Navigation property to define that a product can be
    /// in many sales items
    /// </summary>
    public virtual ICollection<SaleItem>? SalesItems { get; set; }

    /// <summary>
    /// Initializes a new instance of the Product class.
    /// </summary>
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Sets UpdatedAt to UtcNow.
    /// </summary>
    public void Updated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}