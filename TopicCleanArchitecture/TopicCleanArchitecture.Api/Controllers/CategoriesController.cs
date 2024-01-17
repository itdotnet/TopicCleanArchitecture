using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopicCleanArchitecture.Application.Features.Category.Commands.CreateCategory;
using TopicCleanArchitecture.Application.Features.Category.Commands.DeleteCategory;
using TopicCleanArchitecture.Application.Features.Category.Commands.UpdateCategory;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetCategoryDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopicCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            return await _mediator.Send(new GetCategoriesQuery());
        }

        // GET: api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsDto>> Get(int id)
        {
            var category= await _mediator.Send(new GetCategoryDetailsQuery(id));
            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateCategoryCommand category)
        {
            var response = await _mediator.Send(category);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CategoriesController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCategoryCommand category)
        {
            await _mediator.Send(category);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id=id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
