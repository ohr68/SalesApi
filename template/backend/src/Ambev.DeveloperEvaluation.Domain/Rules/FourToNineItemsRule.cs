using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Rules;

/// <summary>
/// Business rule definition for discount
/// Purchases above 4 identical items have a 10% discount
/// </summary>
public class FourToNineItemsRule : IDiscountRule
{
    public decimal CalculateDiscount(SaleItem saleItem)
        => saleItem.Quantity is >= 4 and <= 9 ? 0.10M : 0;
}