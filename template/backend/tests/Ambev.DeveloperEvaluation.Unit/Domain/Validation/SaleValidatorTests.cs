using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleValidator class.
/// Tests cover validation of all sale properties including customer, branch
/// and items
/// </summary>
public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    /// <summary>
    /// Initializes a new instance for SaleValidatorTests class
    /// </summary>
    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// This test verifies that a user with valid:
    /// - Customer (5-100 characters)
    /// - Branch (5-100 characters)
    /// - Items (must have at least one)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid sale should pass all validation rules")]
    public void Given_ValidSale_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        
        // Act
        var result = _validator.TestValidate(sale);
        
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    /// <summary>
    /// Tests that validation fails for invalid customerName formats.
    /// This test verifies that customer names that are:
    /// - Empty strings
    /// - Less than 5 characters
    /// fail validation with appropriate error messages.
    /// The customerName is a required field and must be between 5 and 100 characters.
    /// </summary>
    /// <param name="customerName">The invalid customerName name to test.</param>
    [Theory(DisplayName = "Invalid customerName formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("test")] // Less than 5 characters
    public void Given_InvalidCustomer_When_Validated_Then_ShouldHaveError(string customerName)
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Customer = customerName;

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Customer);
    }
    
    /// <summary>
    /// Tests that validation fails when customerName exceeds maximum length.
    /// This test verifies that customerName longer than 100 characters fail validation.
    /// The test uses TestDataGenerator to create a customerName that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "CustomerName longer than maximum length should fail validation")]
    public void Given_CustomerNameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Customer = SaleTestData.GenerateInvalidCustomerNameMaxLength();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Customer);
    }
    
    /// <summary>
    /// Tests that validation fails for invalid branch formats.
    /// This test verifies that branch names that are:
    /// - Empty strings
    /// - Less than 5 characters
    /// fail validation with appropriate error messages.
    /// The branchName is a required field and must be between 5 and 100 characters.
    /// </summary>
    /// <param name="branchName">The invalid branchName name to test.</param>
    [Theory(DisplayName = "Invalid branchName formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("test")] // Less than 5 characters
    public void Given_InvalidBranchName_When_Validated_Then_ShouldHaveError(string branchName)
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Branch = branchName;

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Branch);
    }
    
    /// <summary>
    /// Tests that validation fails when customerName exceeds maximum length.
    /// This test verifies that customerName longer than 100 characters fail validation.
    /// The test uses TestDataGenerator to create a customerName that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "CustomerName longer than maximum length should fail validation")]
    public void Given_BranchNameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Branch = SaleTestData.GenerateInvalidBranchNameMaxLength();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Branch);
    }

    /// <summary>
    /// Tests that validation fails when sale has no items.
    /// </summary>
    [Fact(DisplayName = "Sale without items should fail validation")]
    public void Given_NoItems_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Items = null;

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.Items);
    }
}