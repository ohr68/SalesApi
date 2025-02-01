using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Handler for processing UpdateProductCommand requests
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateProductHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateProductCommand command
    /// </summary>
    /// <param name="command">The UpdateProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the update operation</returns>
    public async Task<UpdateProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
        
        if(product is null)
            throw new KeyNotFoundException($"Product with ID {command.Id} not found");
        
        var success = await _productRepository.UpdateAsync(_mapper.Map<Product>(command), cancellationToken);

        return new UpdateProductResponse(success);
    }
}