using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.CQRS.Handlers;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(GetCategoryQueryHandler categoryHandler) : ControllerBase
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
    }
}
