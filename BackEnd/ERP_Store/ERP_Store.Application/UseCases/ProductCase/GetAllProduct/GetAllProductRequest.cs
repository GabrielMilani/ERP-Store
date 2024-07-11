using MediatR;

namespace ERP_Store.Application.UseCases.ProductCase.GetAllProduct;

public sealed class GetAllProductRequest : IRequest<List<GetAllProductResponse>>
{
}