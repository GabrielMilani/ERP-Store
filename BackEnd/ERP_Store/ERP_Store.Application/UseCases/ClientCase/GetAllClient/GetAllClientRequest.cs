using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.GetAllClient;

public sealed class GetAllClientRequest : IRequest<List<GetAllClientResponse>>
{
}