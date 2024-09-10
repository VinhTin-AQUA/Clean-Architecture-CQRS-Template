using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog?> GetBlogById(int id);
        Task<Blog> CreateBlog(Blog blog);
        Task<int> UpdateBlog(Blog blog);
        Task<int> DeleteBlog(int id);
    }
}
