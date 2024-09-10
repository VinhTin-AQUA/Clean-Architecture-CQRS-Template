using Application.Features.Blogs.Queries.GetAllBlogs;
using Application.Features.Users.Commands.AddUser;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVM>
    {
        private readonly IBlogRepository blogRepository;
        private readonly ISender sender;
        private readonly IMapper mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, 
            ISender sender,
            IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.sender = sender;
            this.mapper = mapper;
        }

        public async Task<BlogVM> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog()
            {
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
            };
            await blogRepository.CreateBlog(blog);
            var blogVM = mapper.Map<BlogVM>(blog);

            var user = new AddUserCommand
            {
                Name = "AA",
                Email = "AA@gmail.com"
            };
            var r_addUser = await sender.Send(user);

            return blogVM;
        }
    }
}
