using AutoMapper;
using ERP_Store.Domain.Abstractions;
using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleRequest, UpdateSaleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(IUnitOfWork unitOfWork, ISaleRepository saleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResponse> Handle(UpdateSaleRequest request,
                                                    CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.Get(request.Id, cancellationToken);
        if (sale == null) return default;
        sale.Update(request.ClientId, request.ProductId, request.SoldQuantity);
        _saleRepository.Update(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<UpdateSaleResponse>(sale);
    }
}