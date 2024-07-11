using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.DeletePayment;

public sealed class DeletePaymentRequest : IRequest<DeletePaymentResponse>
{
    public int Id { get; set; }
}