using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.MoveStockCase.DeleteMoveStock;

public sealed class DeleteMoveStockMapper : Profile
{
    public DeleteMoveStockMapper()
    {
        CreateMap<DeleteMoveStockRequest, MoveStock>();
        CreateMap<MoveStock, DeleteMoveStockResponse>();
    }
}