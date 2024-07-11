using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.DeleteClient;

public sealed class DeleteClientRequest : IRequest<DeleteClientResponse>
{
    public int Id { get; set; }
}