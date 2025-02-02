namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models.Requests.CreateSaleItem;

/// <summary>
///  Request model for creating a new sale's item.
/// </summary>
/// <remarks>
/// This model is used to capture the required data for creating a sale's item
/// </remarks>
public class CreateSaleItemRequest
{
    /// <summary>
    /// Gets the quantity sold of the item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the id of the product which the item represents.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets whether the item was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }

    /// <summary>
    /// Gets the unit price of the product which the item represents.
    /// </summary>
    public decimal UnitPrice { get; set; }
}