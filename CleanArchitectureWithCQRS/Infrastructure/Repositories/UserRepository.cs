using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly BlogDemoContext context;

        public UserRepository(BlogDemoContext context)
        {
            this.context = context;
        }

        public async Task<int> AddUser(User user)
        {
            context.Add(user);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}
