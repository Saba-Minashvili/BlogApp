using BlogApp.Domain.Abstractions;
using BlogApp.Domain.Blogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Persistence.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasIndex(o => o.Title);

        builder.HasQueryFilter(o => o.Status != nameof(EntityStatus.Deleted));

        builder.Property(o => o.Title).HasMaxLength(50);
    }
}
