using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.GetAllPayment;

public class GetAllPaymentHandler : IRequestHandler<GetAllPaymentRequest, List<GetAllPaymentResponse>>
{
    private readonly IPaymentRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllPaymentHandler(IPaymentRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllPaymentResponse>> Handle(GetAllPaymentRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllPaymentResponse>>(products);
    }
}