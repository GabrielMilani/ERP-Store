using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.ProductCase.MoveStockProduct;

public sealed class MoveStockProductRequest : IRequest<MoveStockProductResponse>
{
    public int Id { get; set; }
    public decimal Quantity { get; set; }
    public string DocumentId { get; set; }
    public EDocumentType EDocumentType { get; set; }
    public EActionMoveStock EActionMoveStock { get; set; }
}