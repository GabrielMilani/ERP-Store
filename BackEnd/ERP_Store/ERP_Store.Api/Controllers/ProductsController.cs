using ERP_Store.Application.UseCases.ProductCase.CreateProduct;
using ERP_Store.Application.UseCases.ProductCase.DeleteProduct;
using ERP_Store.Application.UseCases.ProductCase.GetAllProduct;
using ERP_Store.Application.UseCases.ProductCase.MoveStockProduct;
using ERP_Store.Application.UseCases.ProductCase.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Store.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllProductResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllProductRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var productId = await _mediator.Send(request, cancellationToken);
        return Ok(productId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateProductResponse>>
        Update(int id, UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpPut("movestock/{id}")]
    public async Task<ActionResult<MoveStockProductResponse>> MoveStock(int id, 
                                                                        MoveStockProductRequest request, 
                                                                        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id,
        CancellationToken cancellationToken)
    {
        var deleteProductRequest = new DeleteProductRequest {Id = id};

        var response = await _mediator.Send(deleteProductRequest, cancellationToken);
        return Ok(response);
    }
}