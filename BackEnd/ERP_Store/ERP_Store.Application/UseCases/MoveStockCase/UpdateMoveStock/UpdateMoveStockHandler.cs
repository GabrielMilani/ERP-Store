using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using ERP_Store.Domain.Enuns;
using MediatR;
using System.Reflection.Metadata;

namespace ERP_Store.Application.UseCases.MoveStockCase.UpdateMoveStock;

public class UpdateMoveStockHandler : IRequestHandler<UpdateMoveStockRequest, UpdateMoveStockResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMoveStockRepository _movestockRepository;
    private readonly IMapper _mapper;

    public UpdateMoveStockHandler(IUnitOfWork unitOfWork, IMoveStockRepository movestockRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _movestockRepository = movestockRepository;
        _mapper = mapper;
    }

    public async Task<UpdateMoveStockResponse> Handle(UpdateMoveStockRequest request,
                                                    CancellationToken cancellationToken)
    {
        var movestock = await _movestockRepository.Get(request.Id, cancellationToken);
        if (movestock == null) return default;
        movestock.Update(request.EActionMoveStock, request.QuantityMoved, request.DateMoved, 
                         request.ProductId, request.Product, request.Document, request.DocumentType);
        _movestockRepository.Update(movestock);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<UpdateMoveStockResponse>(movestock);
    }
}