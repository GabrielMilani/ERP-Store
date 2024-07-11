using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleRequest, DeleteSaleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public DeleteSaleHandler(IUnitOfWork unitOfWork, ISaleRepository saleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSaleResponse> Handle(DeleteSaleRequest request, CancellationToken cancellationToken)
    {

        var sale = await _saleRepository.Get(request.Id, cancellationToken);
        if (sale == null) return default;
        _saleRepository.Delete(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<DeleteSaleResponse>(sale);
    }
}