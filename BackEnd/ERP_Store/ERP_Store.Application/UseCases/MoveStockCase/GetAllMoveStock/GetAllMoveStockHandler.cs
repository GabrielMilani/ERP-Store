using AutoMapper;
using ERP_Store.Domain.Abstractions;
using MediatR;

namespace ERP_Store.Application.UseCases.MoveStockCase.GetAllMoveStock;

public class GetAllMoveStockHandler : IRequestHandler<GetAllMoveStockRequest, List<GetAllMoveStockResponse>>
{
    private readonly IMoveStockRepository _movestockRepository;
    private readonly IMapper _mapper;

    public GetAllMoveStockHandler(IMoveStockRepository movestockRepository, IMapper mapper)
    {
        _movestockRepository = movestockRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllMoveStockResponse>> Handle(GetAllMoveStockRequest request, CancellationToken cancellationToken)
    {
        var movestocks = await _movestockRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllMoveStockResponse>>(movestocks);
    }
}