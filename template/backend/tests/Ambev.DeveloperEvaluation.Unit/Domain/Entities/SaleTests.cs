﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that when a sale is canceled, canceled property is set to true.
    /// </summary>
    [Fact(DisplayName = "Sale canceled should be set to true")]
    public void Given_Sale_When_Canceled_Then_CanceledShouldBeTrue()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.Cancelled);
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_Should_Return_Valid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        
        // Act
        var result = sale.Validate();
        
        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
    
    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = SaleTestData.GenerateInvalidCustomerNameMinLength(), // Invalid: min length is 5
            Branch = SaleTestData.GenerateInvalidBranchNameMinLength(), // Invalid: min length is 5
            Items = null // Invalid: must have at least one item
        };

        // Act
        var result = sale.Validate();
        
        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}