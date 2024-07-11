using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.ClientCase.GetAllClient;

public sealed class GetAllClientMapper : Profile
{
    public GetAllClientMapper()
    {
        CreateMap<Client, GetAllClientResponse>();
    }
}