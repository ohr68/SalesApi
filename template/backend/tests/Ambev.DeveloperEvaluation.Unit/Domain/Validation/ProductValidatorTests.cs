using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the ProductValidator class.
/// Tests cover validation of all sale properties including customer, branch
/// and items
/// </summary>
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    /// <summary>
    /// Initializes a new instance for ProductValidatorTests class
    /// </summary>
    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }
    
    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// This test verifies that a product with valid:
    /// - Title (1-100 characters)
    /// - Description (10-300 characters)
    /// - Price (required)
    /// - Category (1-150 characters)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        
        // Act
        var result = _validator.TestValidate(product);
        
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    /// <summary>
    /// Tests that validation fails for invalid title formats.
    /// This test verifies that titles that are:
    /// - Empty strings
    /// fail validation with appropriate error messages.
    /// The title is a required field and must be between 1 and 100 characters.
    /// </summary>
    /// <param name="title">The invalid title name to test.</param>
    [Theory(DisplayName = "Invalid title formats should fail validation")]
    [InlineData("")] // Empty
    public void Given_InvalidTitle_When_Validated_Then_ShouldHaveError(string title)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = title;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Title);
    }
    
    /// <summary>
    /// Tests that validation fails when customerName exceeds maximum length.
    /// This test verifies that customerName longer than 100 characters fail validation.
    /// The test uses TestDataGenerator to create a customerName that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Title longer than maximum length should fail validation")]
    public void Given_TitleLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = ProductTestData.GenerateValidProduct();
        sale.Title = ProductTestData.GenerateInvalidMaxLengthTitle();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Title);
    }
    
    /// <summary>
    /// Tests that validation fails for invalid description formats.
    /// This test verifies that description that are:
    /// - Empty strings
    /// - Less than 10 characters
    /// fail validation with appropriate error messages.
    /// The description is a required field and must be between 10 and 300 characters.
    /// </summary>
    /// <param name="description">The invalid description name to test.</param>
    [Theory(DisplayName = "Invalid description formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("teste1234")] // Less than 10 characters
    public void Given_InvalidDescription_When_Validated_Then_ShouldHaveError(string description)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = description;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }
    
    /// <summary>
    /// Tests that validation fails when description exceeds maximum length.
    /// This test verifies that description longer than 300 characters fail validation.
    /// The test uses TestDataGenerator to create a description that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Description longer than maximum length should fail validation")]
    public void Given_DescriptionLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = ProductTestData.GenerateInvalidMaxLengthDescription();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Tests that validation fails when price is 0.
    /// This test verifies that price is equal to 0 fail validation.
    /// </summary>
    [Fact(DisplayName = "Price 0 should fail validation")]
    public void Given_PriceZero_When_Validated_Then_ShouldNotHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Price = 0;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Price);
    }
    
    /// <summary>
    /// Tests that validation fails when price is less than 0.
    /// This test verifies that price is less than 0 fail validation.
    /// </summary>
    [Fact(DisplayName = "Price less than 0 should fail validation")]
    public void Given_PriceLessZero_When_Validated_Then_ShouldNotHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Price = -1;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Price);
    }
    
    /// <summary>
    /// Tests that validation fails for invalid category formats.
    /// This test verifies that categories that are:
    /// - Empty strings
    /// fail validation with appropriate error messages.
    /// The title is a required field and must be between 1 and 150 characters.
    /// </summary>
    /// <param name="category">The invalid category name to test.</param>
    [Theory(DisplayName = "Invalid category formats should fail validation")]
    [InlineData("")] // Empty
    public void Given_InvalidCategory_When_Validated_Then_ShouldHaveError(string category)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Category = category;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Category);
    }
    
    /// <summary>
    /// Tests that validation fails when category exceeds maximum length.
    /// This test verifies that category longer than 150 characters fail validation.
    /// The test uses TestDataGenerator to create a category that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Category longer than maximum length should fail validation")]
    public void Given_CategoryLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = ProductTestData.GenerateValidProduct();
        sale.Title = ProductTestData.GenerateInvalidMaxLengthCategory();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Title);
    }

}