using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleRequest, CreateSaleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISaleRepository _saleRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(IUnitOfWork unitOfWork, ISaleRepository saleRepository, IPaymentRepository paymentRepository, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _saleRepository = saleRepository;
        _paymentRepository = paymentRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResponse> Handle(CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var sale = _mapper.Map<Sale>(request);
        _saleRepository.Create(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
       
        var product = await _unitOfWork.ProductRepository.Get(sale.ProductId, cancellationToken);
        product.MoveStock(sale.SoldQuantity, EActionMoveStock.remove);
        _productRepository.Update(product);
        await _unitOfWork.CommitAsync(cancellationToken);
        
        var payment = new Payment(sale.Id, sale, (sale.SoldQuantity * product.Price ));
        _paymentRepository.Create(payment);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<CreateSaleResponse>(sale);
    }
}