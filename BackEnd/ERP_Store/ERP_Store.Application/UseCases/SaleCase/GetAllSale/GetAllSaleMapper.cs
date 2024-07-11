using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.SaleCase.GetAllSale;

public sealed class GetAllSaleMapper : Profile
{
    public GetAllSaleMapper()
    {
        CreateMap<Sale, GetAllSaleResponse>();
    }
}