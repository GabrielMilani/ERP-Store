using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.GetAllSale;

public sealed class GetAllSaleRequest : IRequest<List<GetAllSaleResponse>>
{
}