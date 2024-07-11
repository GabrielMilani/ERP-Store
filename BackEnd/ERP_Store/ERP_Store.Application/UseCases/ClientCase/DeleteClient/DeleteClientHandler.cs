using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.DeleteClient;

public class DeleteClientHandler : IRequestHandler<DeleteClientRequest, DeleteClientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public DeleteClientHandler(IUnitOfWork unitOfWork, IClientRepository clientRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<DeleteClientResponse> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
    {

        var client = await _clientRepository.Get(request.Id, cancellationToken);
        if (client == null) return default;
        _clientRepository.Delete(client);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<DeleteClientResponse>(client);
    }
}