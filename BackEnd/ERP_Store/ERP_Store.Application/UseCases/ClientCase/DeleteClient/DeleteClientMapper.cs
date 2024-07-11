using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ClientCase.DeleteClient;

public sealed class DeleteClientMapper : Profile
{
    public DeleteClientMapper()
    {
        CreateMap<DeleteClientRequest, Client>();
        CreateMap<Client, DeleteClientResponse>();
    }
}