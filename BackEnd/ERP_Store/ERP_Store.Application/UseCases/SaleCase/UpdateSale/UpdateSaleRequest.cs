using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.UpdateSale;

public sealed class UpdateSaleRequest : IRequest<UpdateSaleResponse>
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ProductId { get; set; }
    public decimal SoldQuantity { get; set; }
}