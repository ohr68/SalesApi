using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging.Commands;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleProfile : Profile
{
    public CancelSaleProfile()
    {
        CreateMap<Sale, SaleCancelled>();
    }
}