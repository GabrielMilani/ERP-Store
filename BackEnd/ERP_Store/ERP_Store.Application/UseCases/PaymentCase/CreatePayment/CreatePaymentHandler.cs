using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.CreatePayment;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public CreatePaymentHandler(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = _mapper.Map<Payment>(request);
        _paymentRepository.Create(payment);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<CreatePaymentResponse>(payment);
    }
}