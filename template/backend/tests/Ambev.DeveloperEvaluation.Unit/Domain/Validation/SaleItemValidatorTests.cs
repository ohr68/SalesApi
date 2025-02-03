using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleValidatorItem class.
/// Tests cover validation of all sale properties including customer, branch
/// and items
/// </summary>
public class SaleItemValidatorTests
{
    private readonly SaleItemValidator _validator;

    /// <summary>
    /// Initializes a new instance for SaleItemValidatorTests class
    /// </summary>
    public SaleItemValidatorTests()
    {
        _validator = new SaleItemValidator();
    }
    
    /// <summary>
    /// Tests that validation passes when all sale item properties are valid.
    /// This test verifies that a user with valid:
    /// - Quantity (between 1 and 20)
    /// </summary>
    [Fact(DisplayName = "Valid sale item should pass all validation rules")]
    public void Given_ValidSaleItem_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        
        // Act
        var result = _validator.TestValidate(saleItem);
        
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    /// <summary>
    /// Tests that validation fails when quantity exceeds maximum allowed.
    /// This test verifies that quantity is greater than 20 fail validation.
    /// The test uses TestDataGenerator to create a quantity that exceeds the maximum
    /// limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Quantity greater  than maximum should fail validation")]
    public void Given_QuantityGreaterThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        saleItem.Quantity = SaleItemTestData.GenerateInvalidMaxQuantity();

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Quantity);
    }
    
    /// <summary>
    /// Tests that validation fails when quantity is bellow the minimum allowed.
    /// This test verifies that quantity is less than 1 fail validation.
    /// The test uses TestDataGenerator to create a quantity that is bellow the minimum 
    /// limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Quantity less than minimum should fail validation")]
    public void Given_QuantityLessThanMinimum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        saleItem.Quantity = SaleItemTestData.GenerateInvalidMinQuantity();

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Quantity);
    }
}