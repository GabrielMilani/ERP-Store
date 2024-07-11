using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.DeleteSale;

public sealed class DeleteSaleRequest : IRequest<DeleteSaleResponse>
{
    public int Id { get; set; }
}