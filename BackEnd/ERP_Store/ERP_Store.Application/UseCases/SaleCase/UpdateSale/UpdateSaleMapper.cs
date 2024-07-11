using AutoMapper;
using ERP_Store.Application.UseCases.ProductCase.UpdateProduct;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.SaleCase.UpdateSale;

public sealed class UpdateSaleMapper : Profile
{
    public UpdateSaleMapper()
    {
        CreateMap<UpdateSaleRequest, Sale>();
        CreateMap<Sale, UpdateSaleResponse>();
    }
}