using Application.Features.Blogs.Queries.GetAllBlogs;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVM>
    {
        private readonly IMapper mapper;
        private readonly IBlogRepository blogRepository;

        public GetBlogByIdQueryHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            this.mapper = mapper;
            this.blogRepository = blogRepository;
        }

        public async Task<BlogVM> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await blogRepository.GetBlogById(request.Id);
            var blogVM = mapper.Map<BlogVM>(blog);
            return blogVM;
        }
    }
}
