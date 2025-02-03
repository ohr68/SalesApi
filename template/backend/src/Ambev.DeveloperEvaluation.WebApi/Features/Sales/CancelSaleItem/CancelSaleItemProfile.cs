using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Profile for mapping between CancelSaleItemRequest and CancelSaleItemCommand
/// </summary>
public class CancelSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CancelSale operation
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<CancelSaleItemRequest, CancelSaleItemCommand>()
            .ConstructUsing(cr => new CancelSaleItemCommand(cr.SaleId, cr.ItemId));

        CreateMap<CancelSaleItemResult, CancelSaleItemResponse>();
    }
}