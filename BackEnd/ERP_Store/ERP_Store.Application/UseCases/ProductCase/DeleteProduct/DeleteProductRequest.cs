using MediatR;

namespace ERP_Store.Application.UseCases.ProductCase.DeleteProduct;

public sealed class DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public int Id { get; set; }
}