using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.UpdateClient;

public sealed class UpdateClientRequest : IRequest<UpdateClientResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}