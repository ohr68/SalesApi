using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Models.InputModels.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid User entities.
    /// The generated users will have valid:
    /// - Username (using internet usernames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<CreateSaleCommand> CreateSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(c => c.Customer, f => f.Company.CompanyName())
        .RuleFor(c => c.Branch, f => f.Company.CompanyName());

    /// <summary>
    /// Generates a valid User entity with randomized data.
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid User entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand(Guid productId)
    {
        var saleCommand = CreateSaleHandlerFaker.Generate();

        saleCommand.Items = new List<CreateSaleItemInputModel>
        {
            new CreateSaleItemInputModel
            {
                Quantity = 1,
                UnitPrice = new Faker().Random.Decimal(100),
                ProductId = productId
            }
        };

        return saleCommand;
    }
}