using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.CQRS.Commands;
using Onion.Application.Features.CQRS.Handlers;
using Onion.Application.Features.CQRS.Queries;

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

        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var value = await byIdHandler.Handle(new GetCategoryByIdQuery(id));
                return Ok(value);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await createHandler.Handle(command);
            if (result is null)
            {
                return BadRequest("Category creation failed.");
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("update-category")]
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
