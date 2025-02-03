namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Represents a request to update an existing product in the system.
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// Gets the product's unique id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

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
}