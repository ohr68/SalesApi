using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models.Requests;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models.Requests.CreateSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the Customer the sale was made to.
    /// </summary>
    public string Customer { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets or sets the branch that made the sale.
    /// </summary>
    public string Branch { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets or sets whether the sale was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
    
    /// <summary>
    /// Gets or sets the sale's items.
    /// Used as a navigation property on entity configuration.
    /// </summary>
    public ICollection<CreateSaleItemRequest>? Items { get; set; }
}