using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ProductCase.GetAllProduct;

public sealed class GetAllProductMapper : Profile
{
    public GetAllProductMapper()
    {
        CreateMap<Product, GetAllProductResponse>();
    }
}