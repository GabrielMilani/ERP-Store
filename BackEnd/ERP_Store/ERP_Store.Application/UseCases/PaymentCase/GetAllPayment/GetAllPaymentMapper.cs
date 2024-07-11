using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.PaymentCase.GetAllPayment;

public sealed class GetAllPaymentMapper : Profile
{
    public GetAllPaymentMapper()
    {
        CreateMap<Payment, GetAllPaymentResponse>();
    }
}