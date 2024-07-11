using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.CreateSale;

public sealed class CreateSaleRequest : IRequest<CreateSaleResponse>
{
    public int ClientId { get; set; }
    public int ProductId { get; set; }
    public decimal SoldQuantity { get; set; }
}