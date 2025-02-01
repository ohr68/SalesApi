﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductResponse>
{
    /// <summary>
    /// Gets the product's unique id.
    /// </summary>
    public Guid Id { get; set; }
    
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
}