using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<int> AddUser(User user);
    }
}
