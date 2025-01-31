using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.RuleEngines;
using Ambev.DeveloperEvaluation.Domain.Rules;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale's item in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
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
    /// Gets the sale which the item belongs.
    /// Used as a navigation property on entity configuration.
    /// </summary>
    public virtual Sale? Sale { get; set; }

    /// <summary>
    /// Gets the sale which the item belongs.
    /// Used as a navigation property on entity configuration.
    /// </summary>
    public virtual Product? Product { get; set; }

    /// <summary>
    /// Sets the discount for the item based on the business rules.
    /// </summary>
    public void CalculateDiscountPercentage(SaleItem saleItem)
    {
        var ruleType = typeof(IDiscountRule);
        IEnumerable<IDiscountRule?> rules = this.GetType().Assembly.GetTypes()
            .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
            .Select(r => Activator.CreateInstance(r) as IDiscountRule);

        var discountRules = rules as IDiscountRule[] ?? rules.ToArray();
        if (!discountRules.Any())
            return;

        var engine = new DiscountRuleEngine(discountRules!);

        Discounts += (saleItem.Product!.UnitPrice * engine.CalculateDiscountPercentage(saleItem));
    }
}