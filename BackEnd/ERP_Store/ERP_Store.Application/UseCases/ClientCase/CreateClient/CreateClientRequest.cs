using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.CreateClient;

public sealed class CreateClientRequest : IRequest<CreateClientResponse>
{
    public string Name { get; set; }
    public string Email { get; set; }
}