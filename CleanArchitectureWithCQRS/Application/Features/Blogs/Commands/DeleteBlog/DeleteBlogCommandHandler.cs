using Domain.Repositories;
using MediatR;

namespace Application.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogRepository blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var r = await blogRepository.DeleteBlog(request.Id);
            return r;
        }
    }
}
