using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.MoveStockCase.CreateMoveStock;

public class CreateMoveStockHandler : IRequestHandler<CreateMoveStockRequest, CreateMoveStockResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMoveStockRepository _moveStockRepository;
    private readonly IMapper _mapper;

    public CreateMoveStockHandler(IUnitOfWork unitOfWork, IMoveStockRepository moveStockRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _moveStockRepository = moveStockRepository;
        _mapper = mapper;
    }

    public async Task<CreateMoveStockResponse> Handle(CreateMoveStockRequest request, CancellationToken cancellationToken)
    {
        var moveStock = _mapper.Map<MoveStock>(request);
        _moveStockRepository.Create(moveStock);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<CreateMoveStockResponse>(moveStock);
    }
}