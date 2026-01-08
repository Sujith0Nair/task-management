using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Infrastructure.Configuration;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(l => l.Color)
            .HasMaxLength(7);
        builder.HasOne(l => l.Tenant)
            .WithMany()
            .HasForeignKey(l => l.TenantId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(l => new { l.TenantId, l.Name }).IsUnique();
    }
}