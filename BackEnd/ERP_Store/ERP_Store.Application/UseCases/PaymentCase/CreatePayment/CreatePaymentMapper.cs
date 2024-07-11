using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.PaymentCase.CreatePayment;

public sealed class CreatePaymentMapper : Profile
{
    public CreatePaymentMapper()
    {
        CreateMap<CreatePaymentRequest, Payment>();
        CreateMap<Payment, CreatePaymentResponse>();
    }
}