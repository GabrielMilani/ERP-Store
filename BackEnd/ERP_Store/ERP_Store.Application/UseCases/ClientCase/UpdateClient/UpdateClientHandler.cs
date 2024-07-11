using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.UpdateClient;

public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public UpdateClientHandler(IUnitOfWork unitOfWork, IClientRepository clientRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<UpdateClientResponse> Handle(UpdateClientRequest request,
                                                    CancellationToken cancellationToken)
    {
        var client = await _clientRepository.Get(request.Id, cancellationToken);
        if (client == null) return default;
        client.Update(request.Name, request.Email);
        _clientRepository.Update(client);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<UpdateClientResponse>(client);
    }
}