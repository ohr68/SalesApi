using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid User entities.
    /// The generated users will have valid:
    /// - Title (using Commerce ProductName)
    /// - Description (using Commerce ProductDescription)
    /// - Price (using Finance Amount)
    /// - Category (using Commerce Categories)
    /// - Image (using Image PicsumUrl)
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Title, f => f.Commerce.ProductName())
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.Price, f => f.Finance.Amount())
        .RuleFor(p => p.Category, f => f.Commerce.Categories(10).First())
        .RuleFor(p => p.Image, f => f.Image.PicsumUrl());

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }
    
    /// <summary>
    /// Generates an invalid title for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid title.</returns>
    public static string GenerateInvalidTitle()
    {
        return string.Empty;
    }
    
    /// <summary>
    /// Generates an invalid title for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid title.</returns>
    public static string GenerateInvalidMaxLengthTitle()
    {
        return new Faker().Random.String2(101);
    }
    
    /// <summary>
    /// Generates an invalid description for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid description.</returns>
    public static string GenerateInvalidDescription()
    {
        return new Faker().Random.String2(9);
    }
    
    /// <summary>
    /// Generates an invalid description for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid description.</returns>
    public static string GenerateInvalidMaxLengthDescription()
    {
        return new Faker().Random.String2(301);
    }
    
    /// <summary>
    /// Generates an invalid price for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid price.</returns>
    public static decimal GenerateInvalidPrice()
    {
        return 0.0M;
    }
    
    /// <summary>
    /// Generates an invalid category for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid category.</returns>
    public static string GenerateInvalidCategory()
    {
        return string.Empty;
    }
    
    /// <summary>
    /// Generates an invalid category for testing negative scenarios.
    /// </summary>
    /// <returns>An invalid category.</returns>
    public static string GenerateInvalidMaxLengthCategory()
    {
        return new Faker().Random.String2(151);
    }
}