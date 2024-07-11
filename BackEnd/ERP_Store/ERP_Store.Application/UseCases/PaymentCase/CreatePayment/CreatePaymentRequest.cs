using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.CreatePayment;

public sealed class CreatePaymentRequest : IRequest<CreatePaymentResponse>
{
    public int SaleId { get; set; }
    public Sale Sale { get; set; }
    public decimal ValuePay { get; set; }
    public decimal ValuePaid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public EStatusPayment StatusPayment { get; set; }
}