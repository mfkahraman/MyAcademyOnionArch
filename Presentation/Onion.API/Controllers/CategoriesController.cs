using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.CQRS.Commands;
using Onion.Application.Features.CQRS.Handlers;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(GetCategoryQueryHandler categoryHandler,
                                      GetCategoryByIdQueryHandler byIdHandler,
                                      CreateCategoryCommandHandler createHandler,
                                      UpdateCategoryCommandHandler updateHandler,
                                      DeleteCategoryCommandHandler deleteHandler)
                                      : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await categoryHandler.Handle();
            if (values is null || values.Count == 0)
            {
                return NotFound("No categories found.");
            }
            return Ok(values);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var value = await byIdHandler.Handle(new Application.Features.CQRS.Queries.GetCategoryByIdQuery(id));

            if (value is null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            return Ok(value);
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await createHandler.Handle(command);
            if (!result)
            {
                return BadRequest("Failed to create category.");
            }
            return CreatedAtAction(nameof(GetById), new { id = command.Name }, command);
        }

        [HttpPost("update-category")]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            var result = await updateHandler.Handle(command);
            if (!result)
            {
                return BadRequest("Failed to update category.");
            }
            return Ok("Category updated successfully.");
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await deleteHandler.Handle(id);
            if (!result)
            {
                return BadRequest("Failed to delete category.");
            }
            return Ok("Category deleted successfully.");
        }



    }
}
