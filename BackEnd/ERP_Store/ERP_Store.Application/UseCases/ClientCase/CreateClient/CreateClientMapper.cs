using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ClientCase.CreateClient;

public sealed class CreateClientMapper : Profile
{
    public CreateClientMapper()
    {
        CreateMap<CreateClientRequest, Client>();
        CreateMap<Client, CreateClientResponse>();
    }
}