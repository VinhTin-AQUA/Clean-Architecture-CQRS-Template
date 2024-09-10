using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class BlogDemoContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }  
    public DbSet<User> Users { get; set; }

    public BlogDemoContext(DbContextOptions<BlogDemoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
