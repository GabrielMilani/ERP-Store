using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.SaleCase.GetAllSale;

public class GetAllSaleHandler : IRequestHandler<GetAllSaleRequest, List<GetAllSaleResponse>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetAllSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllSaleResponse>> Handle(GetAllSaleRequest request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllSaleResponse>>(sales);
    }
}