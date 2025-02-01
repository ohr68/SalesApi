using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductResult>
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Title { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Image of the product.
    /// </summary>
    public string Image { get; set; } = string.Empty;
}