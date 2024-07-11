using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.MoveStockCase.GetAllMoveStock;

public sealed class GetAllMoveStockMapper : Profile
{
    public GetAllMoveStockMapper()
    {
        CreateMap<MoveStock, GetAllMoveStockResponse>();
    }
}