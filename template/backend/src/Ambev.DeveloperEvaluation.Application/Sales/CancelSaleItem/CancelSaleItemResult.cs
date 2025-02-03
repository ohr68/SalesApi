namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Result model for CancelSaleItem operation
/// </summary>
public class CancelSaleItemResult(bool success)
{
    /// <summary>
    /// Indicates whether the cancellation was successful
    /// </summary>
    public bool Success { get; set; } = success; 
}