using MediatR;

namespace Application.Features.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
