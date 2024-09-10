using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogVM>>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }

        public async Task<List<BlogVM>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blog = await blogRepository.GetAllBlogs();
            //var blogVM = blog.Select(b => new BlogVM
            //{
            //    Author = b.Author,
            //    Name = b.Name,
            //    Description = b.Description,
            //    Id = b.Id,
            //}).ToList();

            var blogVM = mapper.Map<List<BlogVM>>(blog);
            return blogVM;
        }
    }
}
