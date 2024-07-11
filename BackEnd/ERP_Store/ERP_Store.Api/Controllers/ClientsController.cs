using ERP_Store.Application.UseCases.ClientCase.DeleteClient;
using ERP_Store.Application.UseCases.ClientCase.CreateClient;
using ERP_Store.Application.UseCases.ClientCase.GetAllClient;
using ERP_Store.Application.UseCases.ClientCase.UpdateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Store.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllClientResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllClientRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var clientId = await _mediator.Send(request, cancellationToken);
        return Ok(clientId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateClientResponse>>
        Update(int id, UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id,
        CancellationToken cancellationToken)
    {
        var deleteClientRequest = new DeleteClientRequest {Id = id};

        var response = await _mediator.Send(deleteClientRequest, cancellationToken);
        return Ok(response);
    }
}