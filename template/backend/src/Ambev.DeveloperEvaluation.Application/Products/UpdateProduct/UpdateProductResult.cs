﻿namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Response model for UpdateProduct operation
/// </summary>
public class UpdateProductResult(bool success)
{
    /// <summary>
    /// Indicates whether the update was successful
    /// </summary>
    public bool Success { get; set; } = success;
}