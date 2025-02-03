namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Result model for CancelSale operation
/// </summary>
public class CancelSaleResult(bool success)
{
    /// <summary>
    /// Indicates whether the cancellation was successful
    /// </summary>
    public bool Success { get; set; } = success;
}