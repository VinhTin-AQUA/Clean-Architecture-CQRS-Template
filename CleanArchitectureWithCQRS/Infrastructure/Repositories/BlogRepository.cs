using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDemoContext context;

        public BlogRepository(BlogDemoContext context)
        {
            this.context = context;
        }


        public async Task<Blog> CreateBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return blog;
            }
            return new Blog();
        }

        public async Task<int> DeleteBlog(int id)
        {
            var blog = await GetBlogById(id);
            if (blog == null)
            {
                return 0;
            }
            context.Blogs.Remove(blog);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            var r = await context.Blogs.ToListAsync();
            return r;
        }

        public async Task<Blog?> GetBlogById(int id)
        {
            var blog = await context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            return blog;
        }

        public async Task<int> UpdateBlog(Blog blog)
        {
            var _blog = await context.Blogs.Where(b => b.Id == blog.Id).FirstOrDefaultAsync();
            if (_blog == null)
            {
                return 0;
            }
            _blog.Author = blog.Author;
            _blog.Description = blog.Description;
            _blog.Name = blog.Name;
            context.Update(_blog);
            var r = await context.SaveChangesAsync();
            return r;
        }
    }
}
