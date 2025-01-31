using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Rules;

namespace Ambev.DeveloperEvaluation.Domain.RuleEngines;

/// <summary>
/// Used to load all existing discount rules and calculate discount
/// defined by the business rules.
/// </summary>
public class DiscountRuleEngine
{
    private readonly List<IDiscountRule> _rules = new List<IDiscountRule>();

    /// <summary>
    /// Adds all the existing rules to the list.
    /// </summary>
    /// <param name="rules"></param>
    public DiscountRuleEngine(IEnumerable<IDiscountRule> rules)
    {
        _rules.AddRange(rules);
    }

    /// <summary>
    /// Goes through all defined discount rules and applies according to the condition met.
    /// If none are met, the discount will be zero.
    /// </summary>
    /// <param name="saleItem"></param>
    /// <returns></returns>
    public decimal CalculateDiscountPercentage(SaleItem saleItem)
        => _rules.Select(rule => rule.CalculateDiscount(saleItem)).Prepend(0m).Max();
}