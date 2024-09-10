using Application.Features.Blogs.Queries.GetAllBlogs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository userRepository;
        private readonly ISender sender;

        public GetAllUsersHandler(IUserRepository userRepository,
            ISender sender)
        {
            this.userRepository = userRepository;
            this.sender = sender;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAllUsers();

            var r_getBlogs = await sender.Send(new GetBlogsQuery());
            return user;
        }
    }
}
