using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Rules;

/// <summary>
/// Business rule definition for discounts
/// This interface is used with a Rule Engine Pattern to get all
/// the discount rules in this assembly
/// </summary>
public interface IDiscountRule
{
    /// <summary>
    /// Abstraction used to define that the discount
    /// will be applied to a item of the sale
    /// </summary>
    decimal CalculateDiscount(SaleItem saleItem);
}