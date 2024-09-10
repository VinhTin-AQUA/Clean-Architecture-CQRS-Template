using Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        private readonly ISender sender = sender;

        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUsres()
        {
            var users = await sender.Send(new GetAllUsersQuery());
            return Ok(users);
        }
    }
}
