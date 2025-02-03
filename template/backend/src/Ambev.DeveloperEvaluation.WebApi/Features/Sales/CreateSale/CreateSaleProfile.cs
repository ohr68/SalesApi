using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Models.InputModels.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.Models.ViewModels;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models.Requests.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models.Responses;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<SaleItemViewModel, SaleItemResponse>();
        CreateMap<CreateSaleItemRequest, CreateSaleItemInputModel>();
    }
}