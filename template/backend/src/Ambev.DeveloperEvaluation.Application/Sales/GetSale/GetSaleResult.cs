using Ambev.DeveloperEvaluation.Application.Sales.Models.ViewModels;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    /// <summary>
    /// Gets the sale's unique id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the sale's number.
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Gets the Date and time when the sale was made.
    /// Stored in Utc format to avoid timezone issues.
    /// </summary>
    public DateTime MadeOn { get; set; }
    
    /// <summary>
    /// Gets the Customer the sale was made to.
    /// </summary>
    public string Customer { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Gets the branch that made the sale.
    /// </summary>
    public string Branch { get; set; } = String.Empty;
    
    /// <summary>
    /// Gets whether the sale was canceled or not.
    /// </summary>
    public bool Cancelled { get; set; }
    
    /// <summary>
    /// Gets the sale's items.
    /// </summary>
    public virtual ICollection<SaleItemViewModel>? Items { get; set; }
}