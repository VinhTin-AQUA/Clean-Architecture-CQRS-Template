using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Commands.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUserRepository userRepository;

        public AddUserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var r = await userRepository.AddUser(new User { Email = request.Email, Name = request.Name });
            return r;
        }
    }
}
