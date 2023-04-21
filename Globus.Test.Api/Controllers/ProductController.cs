using System.Threading;
using System.Threading.Tasks;
using Globus.Test.Application.Commands.CreateUpdateProduct;
using Globus.Test.Application.Commands.DeleteProduct;
using Globus.Test.Application.Queries.GetProductById;
using Globus.Test.Application.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Globus.Test.Api.Controllers;

public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("api/v1/products")]
    public async Task<IActionResult> Update([FromBody] CreateUpdateProductCommand request, CancellationToken cancellationToken)
    { 
        await _mediator.Send(request, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    [Route("api/v1/products/{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteProductCommand {Id = id}, cancellationToken);

        if (result == int.MinValue)
            return NotFound();
        
        return Ok();
    }

    [HttpGet]
    [Route("api/v1/products/{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProductByIdQuery {Id = id}, cancellationToken);

        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route("api/v1/products")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
        return Ok(result);
    }
}