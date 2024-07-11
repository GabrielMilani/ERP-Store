using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.MoveStockCase.UpdateMoveStock;

public sealed class UpdateMoveStockMapper : Profile
{
    public UpdateMoveStockMapper()
    {
        CreateMap<UpdateMoveStockRequest, MoveStock>();
        CreateMap<MoveStock, UpdateMoveStockResponse>();
    }
}