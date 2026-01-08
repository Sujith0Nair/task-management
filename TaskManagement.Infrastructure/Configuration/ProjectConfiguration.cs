using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Infrastructure.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(p => p.Description)
            .HasMaxLength(2000);
        builder.HasOne(p => p.Tenant)
            .WithMany(t => t.Projects)
            .HasForeignKey(p => p.TenantId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(p => new { p.TenantId, p.Name }).IsUnique();
    }
}