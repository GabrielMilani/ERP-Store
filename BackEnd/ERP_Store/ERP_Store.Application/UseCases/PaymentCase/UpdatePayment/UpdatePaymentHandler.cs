using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.UpdatePayment;

public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentRequest, UpdatePaymentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public UpdatePaymentHandler(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    public async Task<UpdatePaymentResponse> Handle(UpdatePaymentRequest request,
                                                    CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.Get(request.Id, cancellationToken);
        if (payment == null) return default;
        payment.Update(request.SaleId, request.Sale, request.ValuePay, request.ValuePaid, 
                       request.CreatedDate, request.PaymentDate, request.StatusPayment);
        _paymentRepository.Update(payment);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<UpdatePaymentResponse>(payment);
    }
}