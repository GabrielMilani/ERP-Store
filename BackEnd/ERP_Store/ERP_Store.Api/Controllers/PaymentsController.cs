using ERP_Store.Application.UseCases.PaymentCase.CreatePayment;
using ERP_Store.Application.UseCases.PaymentCase.DeletePayment;
using ERP_Store.Application.UseCases.PaymentCase.GetAllPayment;
using ERP_Store.Application.UseCases.PaymentCase.PaidPayment;
using ERP_Store.Application.UseCases.PaymentCase.UpdatePayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Store.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllPaymentResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllPaymentRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var paymentId = await _mediator.Send(request, cancellationToken);
        return Ok(paymentId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdatePaymentResponse>> Update(int id, 
                                                                  UpdatePaymentRequest request, 
                                                                  CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("paid/{id}")]
    public async Task<ActionResult<PaidPaymentResponse>> Paid(int id, 
                                                              PaidPaymentRequest request, 
                                                              CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id,
        CancellationToken cancellationToken)
    {
        var deletePaymentRequest = new DeletePaymentRequest {Id = id};

        var response = await _mediator.Send(deletePaymentRequest, cancellationToken);
        return Ok(response);
    }
}