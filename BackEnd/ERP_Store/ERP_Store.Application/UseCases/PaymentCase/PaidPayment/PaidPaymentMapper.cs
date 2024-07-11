using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.PaymentCase.PaidPayment;

public sealed class PaidPaymentMapper : Profile
{
    public PaidPaymentMapper()
    {
        CreateMap<PaidPaymentRequest, Payment>();
        CreateMap<Payment, PaidPaymentResponse>();
    }
}