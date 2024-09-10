using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
            };
            var r = await blogRepository.UpdateBlog(blog);
            return r;
        }
    }
}
