using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Configuration;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(t => t.Description).HasMaxLength(500);
        builder.Property(t => t.Status).HasMaxLength(50);
        builder.Property(t => t.Priority).HasMaxLength(50);
        builder.Property(t => t.CreatedOn).IsRequired();
        builder.Property(t => t.DueDate).IsRequired(false);
        builder.HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(t => t.Tenant)
            .WithMany()
            .HasForeignKey(t => t.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(t => t.TenantId);
        builder.HasIndex(t => t.BoardId);
        builder.HasMany(t => t.Labels)
            .WithMany(l => l.Tasks)
            .UsingEntity<Dictionary<string, object>>(
                "TaskLabel",
                j => j
                    .HasOne<Label>()
                    .WithMany()
                    .HasForeignKey("LabelId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<Task>()
                    .WithMany()
                    .HasForeignKey("TaskId")
                    .OnDelete(DeleteBehavior.Cascade)
                );
    }
}