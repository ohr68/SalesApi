using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging.Commands;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Profile for mapping between:
/// Sale and SaleModified event
/// SalItem and ItemCancelled event
/// </summary>
public class CancelSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CancelSaleItem operation
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<Sale, SaleModified>();
        CreateMap<SaleItem, ItemCancelled>();
    }
}