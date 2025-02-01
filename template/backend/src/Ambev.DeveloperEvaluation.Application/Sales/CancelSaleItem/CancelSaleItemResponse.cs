namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Response model for CancelSaleItem operation
/// </summary>
public class CancelSaleItemResponse(bool success)
{
    /// <summary>
    /// Indicates whether the cancellation was successful
    /// </summary>
    public bool Success { get; set; } = success; 
}