using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.SaleCase.CreateSale;

public sealed class CreateSaleMapper : Profile
{
    public CreateSaleMapper()
    {
        CreateMap<CreateSaleRequest, Sale>();
        CreateMap<Sale, CreateSaleResponse>();
    }
}