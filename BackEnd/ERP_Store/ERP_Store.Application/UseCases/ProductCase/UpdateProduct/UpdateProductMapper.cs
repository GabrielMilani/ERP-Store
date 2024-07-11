using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ProductCase.UpdateProduct;

public sealed class UpdateProductMapper : Profile
{
    public UpdateProductMapper()
    {
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<Product, UpdateProductResponse>();
    }
}