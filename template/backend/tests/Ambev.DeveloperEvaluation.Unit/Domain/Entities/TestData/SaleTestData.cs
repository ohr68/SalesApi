using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{

    /// <summary>
    /// Configures the Faker to generate valid User entities.
    /// The generated users will have valid:
    /// - Number (using random number)
    /// - MadeOn (using recent DateTime)
    /// - UpdatedAt (using recent DateTime)
    /// - Customer (using Company CompanyName)
    /// - TotalAmount (using Finance Amount)
    /// - Branch (using Company CompanyName)
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.Number, f => f.Random.Number(1000))
        .RuleFor(s => s.MadeOn, f => f.Date.Recent())
        .RuleFor(s => s.UpdatedAt, f => f.Date.Recent())
        .RuleFor(s => s.Customer, f => f.Company.CompanyName())
        .RuleFor(s => s.TotalAmount, f => f.Finance.Amount())
        .RuleFor(s => s.Branch, f => f.Company.CompanyName());

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        var sale = SaleFaker.Generate();
        sale.Items = new List<SaleItem>()
        {
            new SaleItem()
            {
                Cancelled = false,
                TotalAmount = 10,
                Discounts = 0,
                Quantity = 2,
                ProductId = Guid.NewGuid(),
            }
        };
        
        return sale;
    }

    /// <summary>
    /// Generates an invalid customer name for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid customer name.</returns>
    public static string GenerateInvalidCustomer()
    {
        return string.Empty;
    }

    /// <summary>
    /// Generates an invalid customer name for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid customer name.</returns>
    public static string GenerateInvalidCustomerNameMinLength()
    {
        return new Faker().Random.String2(4);
    }
    
    /// <summary>
    /// Generates an invalid customer name for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid customer name.</returns>
    public static string GenerateInvalidCustomerNameMaxLength()
    {
        return new Faker().Random.String2(101);
    }

    /// <summary>
    /// Generates an invalid branch name for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid branch name.</returns>
    public static string GenerateInvalidBranchName()
    {
        return string.Empty;
    }
    
    /// <summary>
    /// Generates an invalid branch name for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid branch name.</returns>
    public static string GenerateInvalidBranchNameMinLength()
    {
        return new Faker().Random.String2(4);
    }
    
    /// <summary>
    /// Generates an invalid branch name for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid branch name.</returns>
    public static string GenerateInvalidBranchNameMaxLength()
    {
        return new Faker().Random.String2(101);
    }
}