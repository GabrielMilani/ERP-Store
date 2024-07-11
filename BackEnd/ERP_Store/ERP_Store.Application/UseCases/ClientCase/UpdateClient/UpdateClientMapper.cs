using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ClientCase.UpdateClient;

public sealed class UpdateClientMapper : Profile
{
    public UpdateClientMapper()
    {
        CreateMap<UpdateClientRequest, Client>();
        CreateMap<Client, UpdateClientResponse>();
    }
}