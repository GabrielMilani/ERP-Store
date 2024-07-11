using MediatR;

namespace ERP_Store.Application.UseCases.MoveStockCase.GetAllMoveStock;

public sealed class GetAllMoveStockRequest : IRequest<List<GetAllMoveStockResponse>>
{
}