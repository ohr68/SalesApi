namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Request for cancel a sale's item
/// </summary>
public class CancelSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// The unique identifier of the item to cancel
    /// </summary>
    public Guid ItemId { get; set; }
}