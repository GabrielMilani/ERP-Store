using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.GetAllPayment;

public sealed class GetAllPaymentRequest : IRequest<List<GetAllPaymentResponse>>
{
}