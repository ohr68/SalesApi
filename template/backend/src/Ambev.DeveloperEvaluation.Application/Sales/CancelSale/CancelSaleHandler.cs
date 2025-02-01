using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Domain.Messaging.Commands;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Handler for processing CancelSaleCommand requests
/// </summary>
public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IQueueService _queueService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CancelSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="queueService">The service responsible to send messages to the queue</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CancelSaleHandler(ISaleRepository saleRepository, IQueueService queueService, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _queueService = queueService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CancelSaleCommand command
    /// </summary>
    /// <param name="command">The CancelSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the cancel operation</returns>
    public async Task<CancelSaleResponse> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);

        if (sale is null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        sale.Cancel();
        var success = await _saleRepository.UpdateAsync(sale, cancellationToken);

        await _queueService.Publish(_mapper.Map<SaleCancelled>(sale), cancellationToken);
        
        return new CancelSaleResponse(success);
    }
}