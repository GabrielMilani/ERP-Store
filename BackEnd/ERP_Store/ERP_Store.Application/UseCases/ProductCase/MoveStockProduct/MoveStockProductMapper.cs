using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ProductCase.MoveStockProduct;

public sealed class MoveStockProductMapper : Profile
{
    public MoveStockProductMapper()
    {
        CreateMap<MoveStockProductRequest, Product>();
        CreateMap<Product, MoveStockProductResponse>();
    }
}