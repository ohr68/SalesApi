using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleItemTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// The generated users will have valid:
    /// - Quantity (using Random int)
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .RuleFor(si => si.Quantity, f => f.Random.Int(1, 20));
    
    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// The generated users will have valid:
    /// - Quantity (using Random int)
    /// - TotalAmount (using Finance Amount)
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemMinQuantityFaker = new Faker<SaleItem>()
        .RuleFor(si => si.Quantity, f => f.Random.Int(4, 9));

    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// The generated users will have valid:
    /// - Quantity (using Random int)
    /// - TotalAmount (using Finance Amount)
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemMaxQuantityFaker = new Faker<SaleItem>()
        .RuleFor(si => si.Quantity, f => f.Random.Int(10, 20));
    
    /// <summary>
    /// Generates a valid SaleItem entity with randomized data.
    /// The generated sale item will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleItem entity with randomly generated data.</returns>
    public static SaleItem GenerateValidSaleItem()
    {
        var saleItem = SaleItemFaker.Generate();
        var productId = Guid.NewGuid();
        
        saleItem.ProductId = productId;
        saleItem.Product = new Product()
        {
            Id = productId,
            Category = new Faker().Commerce.Categories(1).First(),
            Image = new Faker().Image.PlaceImgUrl(),
            Price = new Faker().Finance.Amount(),
            CreatedAt = DateTime.UtcNow,
        };

        return saleItem;
    }
    
    /// <summary>
    /// Generates a valid SaleItem entity with randomized data respecting quantity for 10% discount rules.
    /// The generated sale item will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleItem entity with randomly generated data.</returns>
    public static SaleItem GenerateValidSaleItemMinQuantity()
    {
        var saleItem = SaleItemMinQuantityFaker.Generate();
        var productId = Guid.NewGuid();
        
        saleItem.ProductId = productId;
        saleItem.Product = new Product()
        {
            Id = productId,
            Category = new Faker().Commerce.Categories(1).First(),
            Image = new Faker().Image.PlaceImgUrl(),
            Price = new Faker().Finance.Amount(),
            CreatedAt = DateTime.UtcNow,
        };

        return saleItem;
    }
    
    /// <summary>
    /// Generates a valid SaleItem entity with randomized data respecting quantity for 20% discount rules.
    /// The generated sale item will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleItem entity with randomly generated data.</returns>
    public static SaleItem GenerateValidSaleItemMaxQuantity()
    {
        var saleItem = SaleItemMaxQuantityFaker.Generate();
        var productId = Guid.NewGuid();
        
        saleItem.ProductId = productId;
        saleItem.Product = new Product()
        {
            Id = productId,
            Category = new Faker().Commerce.Categories(1).First(),
            Image = new Faker().Image.PlaceImgUrl(),
            Price = new Faker().Finance.Amount(),
            CreatedAt = DateTime.UtcNow,
        };

        return saleItem;
    }

    /// <summary>
    /// Generates an invalid quantity for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid quantity.</returns>
    public static int GenerateInvalidMinQuantity()
    {
        return 0;
    }
    
    /// <summary>
    /// Generates an invalid quantity for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid quantity.</returns>
    public static int GenerateInvalidMaxQuantity()
    {
        return 20;
    }
}