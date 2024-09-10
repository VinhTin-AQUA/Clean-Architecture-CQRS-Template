using MediatR;

namespace Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetBlogsQuery : IRequest<List<BlogVM>>
    {
    }
}
