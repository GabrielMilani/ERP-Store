using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.MoveStockCase.CreateMoveStock;

public sealed class CreateMoveStockMapper : Profile
{
    public CreateMoveStockMapper()
    {
        CreateMap<CreateMoveStockRequest, MoveStock>();
        CreateMap<MoveStock, CreateMoveStockResponse>();
    }
}