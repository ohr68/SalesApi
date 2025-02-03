using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Rules;

/// <summary>
/// Business rule definition for discount
/// Purchases above 4 identical items have a 10% discount
/// </summary>
public class TenToTwentyItemsRule : IDiscountRule
{
    public decimal CalculateDiscount(SaleItem saleItem)
        => saleItem.Quantity is >= 10 and <= 20 ? 0.20M : 0;
}