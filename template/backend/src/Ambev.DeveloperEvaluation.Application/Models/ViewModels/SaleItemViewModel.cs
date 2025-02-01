namespace Ambev.DeveloperEvaluation.Application.Models.ViewModels;

public class SaleItemViewModel
{
    /// <summary>
    /// Gets the quantity sold of the item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the discounts for the item.
    /// </summary>
    public decimal Discounts { get; set; }

    /// <summary>
    /// Gets the total amount of the item.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets whether the item was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }

    /// <summary>
    /// Gets the id of the sale which the item belongs.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the id of the product which the item represents.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the product which the item represents.
    /// Used as a navigation property on entity configuration.
    /// </summary>
    public string Product { get; set; } = string.Empty;

}