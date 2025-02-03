using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the SaleItem entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleItemTests
{
    /// <summary>
    /// Tests that when a sale item is canceled, canceled property is set to true.
    /// </summary>
    [Fact(DisplayName = "Sale item canceled should be set to true")]
    public void Given_Sale_Item_When_Canceled_Then_CanceledShouldBeTrue()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem();

        // Act
        saleItem.Cancel();

        // Assert
        Assert.True(saleItem.Cancelled);
    }

    /// <summary>
    /// Tests that validation passes when all sale item properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale item data")]
    public void Given_ValidSaleItemData_When_Validated_Then_Should_Return_Valid()
    {
        // Arrange
        var sale = SaleItemTestData.GenerateValidSaleItem();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale item data")]
    public void Given_InvalidSaleItemData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            Quantity = 0, // Invalid: 0
        };

        // Act
        var result = saleItem.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
    
    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail when exceeding the maximum number of items")]
    public void Given_Exceeding_NumberOfItems_Then_ShouldReturnInvalid()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            Quantity = 21, // Invalid: 21
        };

        // Act
        var result = saleItem.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that 10% discount will be applied according business rules.
    /// </summary>
    [Fact(DisplayName = "10% discount should be applied to sale item")]
    public void Given_SaleItem_Then_TenPercentDiscountShouldBeApplied()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItemMinQuantity();
        
        // Act
        saleItem.CalculateDiscountPercentage();
        
        // Assert
        Assert.Equal(saleItem.Discounts, saleItem.Product!.Price * 0.10M);
    }
    
    /// <summary>
    /// Tests that 20% discount will be applied according business rules.
    /// </summary>
    [Fact(DisplayName = "20% discount should be applied to sale item")]
    public void Given_SaleItem_Then_TwentyDiscountShouldBeApplied()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItemMaxQuantity();
        
        // Act
        saleItem.CalculateDiscountPercentage();
        
        // Assert
        Assert.Equal(saleItem.Discounts, saleItem.Product!.Price * 0.20M);
    }
}