using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging.Commands;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemProfile : Profile
{
    public CancelSaleItemProfile()
    {
        CreateMap<Sale, SaleModified>();
        CreateMap<SaleItem, ItemCancelled>();
    }
}