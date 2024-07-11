using AutoMapper;
using ERP_Store.Domain.Abstractions;
using MediatR;

namespace ERP_Store.Application.UseCases.ClientCase.GetAllClient;

public class GetAllClientHandler : IRequestHandler<GetAllClientRequest, List<GetAllClientResponse>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public GetAllClientHandler(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllClientResponse>> Handle(GetAllClientRequest request, CancellationToken cancellationToken)
    {
        var clients = await _clientRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllClientResponse>>(clients);
    }
}