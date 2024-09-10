using Application.Features.Blogs.Queries.GetAllBlogs;
using MediatR;

namespace Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogVM>
    {
        public int Id { get; set; }
    }
}
