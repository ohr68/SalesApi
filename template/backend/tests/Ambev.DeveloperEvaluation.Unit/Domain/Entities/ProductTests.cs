using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class ProductTests
{
    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid product data")]
    public void Given_ValidProductData_When_Validated_Then_Should_Return_Valid()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        
        // Act
        var result = product.Validate();
        
        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
    
    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var product = new Product()
        {
            Title = ProductTestData.GenerateInvalidTitle(), // Invalid: min length is 1
            Description = ProductTestData.GenerateInvalidDescription(), // Invalid: min length is 10
            Price = ProductTestData.GenerateInvalidPrice(), // Invalid: must have a price,
            Category = ProductTestData.GenerateInvalidCategory(),
        };

        // Act
        var result = product.Validate();
        
        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}