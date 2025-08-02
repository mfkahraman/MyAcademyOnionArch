using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Features.Mediator.Queries;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAll()
        {
            var products = await mediator.Send(new GetProductQuery());

            if (products is null || products.Count == 0)
            {
                return NotFound("No products found.");
            }

            return Ok(products);
        }

        [HttpGet("get-product-by-id/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));
            if (product is null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(product);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await mediator.Send(command);

            if (result is null || result.Id == Guid.Empty)
            {
                return BadRequest("Product creation failed.");
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var result = await mediator.Send(command);
            if (!result)
            {
                return NotFound($"Product with ID {command.Id} not found.");
            }
            return Ok(result);
        }

        [HttpDelete("delete-product/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteProductCommand(id));
            if (!result)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
