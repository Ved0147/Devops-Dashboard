using DevOpsDashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevOpsDashboard.Infrastructure.Persistence.Configurations;

public class DeploymentConfiguration : IEntityTypeConfiguration<Deployment>
{
    public void Configure(EntityTypeBuilder<Deployment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ServiceName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Environment)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CommitHash)
            .HasMaxLength(100);

        builder.Property(x => x.BranchName)
            .HasMaxLength(100);

        builder.Property(x => x.TriggeredBy)
            .HasMaxLength(100);
    }
}