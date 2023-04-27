using BlogApp.Domain.Abstractions;
using BlogApp.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasIndex(o => o.Email).IsUnique();

        builder.HasQueryFilter(o => o.Status != nameof(EntityStatus.Deleted));

        builder.Property(o => o.FirstName).HasMaxLength(50);
        builder.Property(o => o.LastName).HasMaxLength(50);
        builder.Property(o => o.Email).IsUnicode(true).HasMaxLength(150);
        builder.Property(o => o.Password).IsUnicode(true).HasMaxLength(300);
    }
}
