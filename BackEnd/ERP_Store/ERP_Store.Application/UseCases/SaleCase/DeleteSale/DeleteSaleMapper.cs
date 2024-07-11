using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.SaleCase.DeleteSale;

public sealed class DeleteSaleMapper : Profile
{
    public DeleteSaleMapper()
    {
        CreateMap<DeleteSaleRequest, Sale>();
        CreateMap<Sale, DeleteSaleResponse>();
    }
}