using AutoMapper;
using ERP_Store.Domain.Abstractions;
using ERP_Store.Domain.Entities;
using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.CreateClient;

public class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public CreateClientHandler(IUnitOfWork unitOfWork, IClientRepository clientRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request);
        _clientRepository.Create(client);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<CreateClientResponse>(client);
    }
}