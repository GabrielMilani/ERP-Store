using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.PaymentCase.UpdatePayment;

public sealed class UpdatePaymentMapper : Profile
{
    public UpdatePaymentMapper()
    {
        CreateMap<UpdatePaymentRequest, Payment>();
        CreateMap<Payment, UpdatePaymentResponse>();
    }
}