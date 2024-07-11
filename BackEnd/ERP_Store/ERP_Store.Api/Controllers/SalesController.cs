using ERP_Store.Application.UseCases.SaleCase.CreateSale;
using ERP_Store.Application.UseCases.SaleCase.DeleteSale;
using ERP_Store.Application.UseCases.SaleCase.GetAllSale;
using ERP_Store.Application.UseCases.SaleCase.UpdateSale;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Store.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllSaleResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllSaleRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var saleId = await _mediator.Send(request, cancellationToken);
        return Ok(saleId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateSaleResponse>>
        Update(int id, UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id,
        CancellationToken cancellationToken)
    {
        var deleteSaleRequest = new DeleteSaleRequest {Id = id};

        var response = await _mediator.Send(deleteSaleRequest, cancellationToken);
        return Ok(response);
    }
}