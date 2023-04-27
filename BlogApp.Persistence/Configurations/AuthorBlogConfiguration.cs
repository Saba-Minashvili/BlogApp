using BlogApp.Domain.AuthorsBlogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Persistence.Configurations;

public class AuthorBlogConfiguration : IEntityTypeConfiguration<AuthorBlog>
{
    public void Configure(EntityTypeBuilder<AuthorBlog> builder)
    {
        builder.HasKey(o => new { o.UserId, o.BlogId });

        builder.HasOne(o => o.User)
            .WithMany(o => o.Blogs)
            .HasForeignKey(o => o.UserId);

        builder.HasOne(o => o.Blog)
            .WithMany(o => o.Authors)
            .HasForeignKey(o => o.BlogId);
    }
}
