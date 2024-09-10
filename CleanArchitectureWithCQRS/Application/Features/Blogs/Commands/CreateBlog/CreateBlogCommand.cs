using Application.Features.Blogs.Queries.GetAllBlogs;
using MediatR;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<BlogVM>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}
