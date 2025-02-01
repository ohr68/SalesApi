using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Command for cancel a sale's item
/// </summary>
public class CancelSaleItemCommand : IRequest<CancelSaleItemResponse>
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid SaleId { get; }
    
    /// <summary>
    /// The unique identifier of the item to cancel
    /// </summary>
    public Guid ItemId { get; }
    
    /// <summary>
    /// Initializes a new instance of CancelSaleCommand
    /// </summary>
    /// <param name="saleId">The ID of the sale</param>
    /// <param name="itemId">The ID of the item to cancel</param>
    public CancelSaleItemCommand(Guid saleId, Guid itemId)
    {
        SaleId = saleId;
        ItemId = itemId;
    }
}