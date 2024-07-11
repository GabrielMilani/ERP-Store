using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.MoveStockCase.DeleteMoveStock;

public class DeleteMoveStockHandler : IRequestHandler<DeleteMoveStockRequest, DeleteMoveStockResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMoveStockRepository _movestockRepository;
    private readonly IMapper _mapper;

    public DeleteMoveStockHandler(IUnitOfWork unitOfWork, IMoveStockRepository movestockRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _movestockRepository = movestockRepository;
        _mapper = mapper;
    }

    public async Task<DeleteMoveStockResponse> Handle(DeleteMoveStockRequest request, CancellationToken cancellationToken)
    {

        var movestock = await _movestockRepository.Get(request.Id, cancellationToken);
        if (movestock == null) return default;
        _movestockRepository.Delete(movestock);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<DeleteMoveStockResponse>(movestock);
    }
}