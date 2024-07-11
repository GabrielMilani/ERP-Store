using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ProductCase.CreateProduct;

public sealed class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, CreateProductResponse>();
    }
}