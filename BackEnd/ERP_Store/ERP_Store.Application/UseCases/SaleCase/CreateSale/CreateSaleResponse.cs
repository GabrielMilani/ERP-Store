using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;

namespace ERP_Store.Application.UseCases.SaleCase.CreateSale;

public sealed class CreateSaleResponse
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public decimal SoldQuantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public EStatusSale StatusSale { get; set; }
}