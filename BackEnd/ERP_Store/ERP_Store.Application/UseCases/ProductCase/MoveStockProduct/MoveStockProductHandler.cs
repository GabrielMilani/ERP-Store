using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;

namespace ERP_Store.Application.UseCases.ProductCase.MoveStockProduct;

public class MoveStockProductHandler : IRequestHandler<MoveStockProductRequest, MoveStockProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IMoveStockRepository _moveStockRepository;
    private readonly IMapper _mapper;

    public MoveStockProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, 
                                    IMoveStockRepository moveStockRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _moveStockRepository = moveStockRepository;
        _mapper = mapper;
    }

    public async Task<MoveStockProductResponse> Handle(MoveStockProductRequest request,
                                                    CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.Id, cancellationToken);
        if (product == null) return default;
        product.MoveStock(request.Quantity, request.EActionMoveStock);
        _productRepository.Update(product);
        var moveStock = new MoveStock(EActionMoveStock.insert, request.Quantity, DateTime.UtcNow, product.Id,
                                    product, request.DocumentId, request.EDocumentType);
        _moveStockRepository.Create(moveStock);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<MoveStockProductResponse>(product);
    }
}