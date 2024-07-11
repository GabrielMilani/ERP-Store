using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.PaymentCase.PaidPayment;

public class PaidPaymentHandler : IRequestHandler<PaidPaymentRequest, PaidPaymentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMoveStockRepository _moveStockRepository;
    private readonly IMapper _mapper;

    public PaidPaymentHandler(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, ISaleRepository saleRepository, IMoveStockRepository moveStockRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _saleRepository = saleRepository;
        _moveStockRepository = moveStockRepository;
        _mapper = mapper;
    }

    public async Task<PaidPaymentResponse> Handle(PaidPaymentRequest request,
                                                    CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.Get(request.Id, cancellationToken);
        if (payment == null) return default;
        payment.Paid(request.ValuePaid);
        _paymentRepository.Update(payment);

        var sale = await _saleRepository.Get(payment.SaleId, cancellationToken);
        if (payment.StatusPayment == EStatusPayment.Paid)
            sale.Closing();

        var product = await _unitOfWork.ProductRepository.Get(sale.ProductId, cancellationToken);
        var moveStock = new MoveStock(EActionMoveStock.remove, sale.SoldQuantity, DateTime.UtcNow, product.Id,
            product, sale.Id.ToString(), EDocumentType.Sale);
        _moveStockRepository.Create(moveStock);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PaidPaymentResponse>(payment);
    }
}