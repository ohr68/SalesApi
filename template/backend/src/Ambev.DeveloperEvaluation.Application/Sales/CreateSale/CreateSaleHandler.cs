using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Domain.Messaging.Commands;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IQueueService _queueService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="productRepository">The product repository</param>
    /// <param name="queueService">The service responsible to send messages to the queue</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IProductRepository productRepository,
        IQueueService queueService, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
        _queueService = queueService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await ValidateProducts(command, cancellationToken);

        var sale = _mapper.Map<Sale>(command);

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        await _queueService.Publish(_mapper.Map<SaleCreated>(createdSale), cancellationToken);

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }

    private async Task ValidateProducts(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var itemsIds = command.Items!.Select(i => i.ProductId).ToList();
        var existingProducts =
            await _productRepository.GetManyByIdAsync(itemsIds, cancellationToken) ?? new List<Guid>();
        var nonExistingProducts = itemsIds.Except(existingProducts).ToList();

        if (nonExistingProducts.Any())
            throw new KeyNotFoundException(
                $"The products with ids {String.Join(",", nonExistingProducts)} were not found");
    }
}