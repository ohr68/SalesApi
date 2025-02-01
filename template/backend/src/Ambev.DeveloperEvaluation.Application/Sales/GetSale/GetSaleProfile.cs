using Ambev.DeveloperEvaluation.Application.Models.ViewModels;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Profile for mapping between Sale entity and GetSaleResponse
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>();
        CreateMap<SaleItem, SaleItemViewModel>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product!.Title));
    }
}