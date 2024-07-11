using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ProductCase.DeleteProduct;

public sealed class DeleteProductMapper : Profile
{
    public DeleteProductMapper()
    {
        CreateMap<DeleteProductRequest, Product>();
        CreateMap<Product, DeleteProductResponse>();
    }
}