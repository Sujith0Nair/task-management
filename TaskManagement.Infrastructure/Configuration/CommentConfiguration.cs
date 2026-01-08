using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Infrastructure.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Content)
            .IsRequired()
            .HasMaxLength(2000);
        builder.Property(c => c.CreatedDate)
            .IsRequired();
        builder.HasOne(c => c.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(c => c.TaskId);
        builder.HasIndex(c => c.UserId);
    }
}