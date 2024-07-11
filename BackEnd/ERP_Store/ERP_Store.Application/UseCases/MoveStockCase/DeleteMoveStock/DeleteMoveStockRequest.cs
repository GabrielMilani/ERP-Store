using MediatR;

namespace ERP_Store.Application.UseCases.MoveStockCase.DeleteMoveStock;

public sealed class DeleteMoveStockRequest : IRequest<DeleteMoveStockResponse>
{
    public int Id { get; set; }
}