using AutoMapper;
using ERP_Store.Domain.Entities;

namespace ERP_Store.Application.UseCases.PaymentCase.DeletePayment;

public sealed class DeletePaymentMapper : Profile
{
    public DeletePaymentMapper()
    {
        CreateMap<DeletePaymentRequest, Payment>();
        CreateMap<Payment, DeletePaymentResponse>();
    }
}