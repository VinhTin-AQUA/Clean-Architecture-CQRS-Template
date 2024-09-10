using Application.Features.Blogs.Commands.CreateBlog;
using Application.Features.Blogs.Commands.DeleteBlog;
using Application.Features.Blogs.Commands.UpdateBlog;
using Application.Features.Blogs.Queries.GetAllBlogs;
using Application.Features.Blogs.Queries.GetBlogById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ISender sender;

        public BlogsController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet("get-all-blogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await sender.Send(new GetBlogsQuery());

            return Ok(new { blogs });
        }


        [HttpGet("get-all-blog-by-id/{id}")]
        public async Task<IActionResult> GetAllBlogs(int id)
        {
            var blog = await sender.Send(new GetBlogByIdQuery() { Id = id });

            return Ok(new { blog });
        }

        [HttpPost("add-blog")]
        public async Task<IActionResult> AddBlog(CreateBlogCommand command)
        {
            var r = await sender.Send(command);
            return Ok(new { r });
        }


        [HttpPut("update-blog")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            var r = await sender.Send(command);
            return Ok(new { r });
        }

        [HttpDelete("remove-blog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var r = await sender.Send(new DeleteBlogCommand() { Id = id});
            return Ok(new { r });
        }
    }
}
