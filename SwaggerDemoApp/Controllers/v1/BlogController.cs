using MediatR;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemoApp.UseCases.Blog.Commands;
using SwaggerDemoApp.UseCases.Blog.DTOs;
using SwaggerDemoApp.UseCases.Blog.Queries;

namespace SwaggerDemoApp.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var response = await _mediator.Send(new GetAllBlogsQuery());

            if (response.ResponseType == Enums.ResponseType.Success)
                return Ok(response.Data);
            return StatusCode(500, response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreateOrUpdateBlogDTO dto)
        {
            var response = await _mediator.Send(new CreateOrUpdateBlogCommand(dto));

            if (response.ResponseType == Enums.ResponseType.Success)
                return Ok(response.Data);
            return StatusCode(500, response.Message);
        }
    }
}