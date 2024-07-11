using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.ProductCase.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request,
                                                    CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.Id, cancellationToken);
        if (product == null) return default;
        product.Update(request.Name, request.Description, request.Price, request.Quantity);
        _productRepository.Update(product);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<UpdateProductResponse>(product);
    }
}