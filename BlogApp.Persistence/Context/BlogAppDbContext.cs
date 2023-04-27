using BlogApp.Domain.AuthorsBlogs;
using BlogApp.Domain.Blogs;
using BlogApp.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistence.Context;

public class BlogAppDbContext : DbContext
{
    public BlogAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<AuthorBlog> AuthorBlogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(BlogAppDbContext).Assembly);
    }
}