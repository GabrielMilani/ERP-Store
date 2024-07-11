using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.DeletePayment;

public class DeletePaymentHandler : IRequestHandler<DeletePaymentRequest, DeletePaymentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public DeletePaymentHandler(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    public async Task<DeletePaymentResponse> Handle(DeletePaymentRequest request, CancellationToken cancellationToken)
    {

        var payment = await _paymentRepository.Get(request.Id, cancellationToken);
        if (payment == null) return default;
        _paymentRepository.Delete(payment);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<DeletePaymentResponse>(payment);
    }
}