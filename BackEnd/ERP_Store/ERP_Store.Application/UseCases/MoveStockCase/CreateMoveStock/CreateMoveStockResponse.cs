using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;

namespace ERP_Store.Application.UseCases.MoveStockCase.CreateMoveStock;

public sealed class CreateMoveStockResponse
{
    public int Id { get; set; }
    public EActionMoveStock EActionMoveStock { get; set; }
    public decimal QuantityMoved { get; set; }
    public DateTime DateMoved { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string Document { get; set; }
    public EDocumentType DocumentType { get; set; }
}