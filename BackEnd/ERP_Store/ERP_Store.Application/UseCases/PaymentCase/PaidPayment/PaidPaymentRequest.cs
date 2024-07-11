using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.PaidPayment;

public sealed class PaidPaymentRequest : IRequest<PaidPaymentResponse>
{
    public int Id { get; set; }
    public decimal ValuePaid { get; set; }
}