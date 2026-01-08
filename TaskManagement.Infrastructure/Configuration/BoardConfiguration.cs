using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Infrastructure.Configuration;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(b => b.Description).HasMaxLength(500);
        builder.HasOne(b => b.Project)
            .WithMany(p => p.Boards)
            .HasForeignKey(b => b.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(b => b.ProjectId);
    }
}