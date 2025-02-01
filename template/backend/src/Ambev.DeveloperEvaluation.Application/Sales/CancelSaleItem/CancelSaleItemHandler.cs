using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Domain.Messaging.Commands;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Handler for processing CancelSaleItemCommand requests
/// </summary>
public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IQueueService _queueService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CancelSaleItemHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="queueService">The service responsible to send messages to the queue</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CancelSaleItemHandler(ISaleRepository saleRepository, IQueueService queueService, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _queueService = queueService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CancelSaleItemCommand request
    /// </summary>
    /// <param name="request">The CancelSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the cancel operation</returns>
    public async Task<CancelSaleItemResponse> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);

        if (sale is null)
            throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found");

        SaleItem? item = null;
        foreach (var saleItem in sale.Items!.Where(si => si.Id == request.ItemId))
        {
            saleItem.Cancel();
            item = saleItem;
        }

        if (item is null)
            throw new KeyNotFoundException($"Item with ID {request.ItemId} not found");

        var success = await _saleRepository.UpdateAsync(sale, cancellationToken);

        await _queueService.Publish(_mapper.Map<SaleModified>(sale), cancellationToken);
        await _queueService.Publish(_mapper.Map<ItemCancelled>(item), cancellationToken);

        return new CancelSaleItemResponse(success);
    }
}