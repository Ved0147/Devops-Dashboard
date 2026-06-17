using DevOpsDashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOpsDashboard.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Deployment> Deployments => Set<Deployment>();

    public DbSet<HealthCheck> HealthChecks => Set<HealthCheck>();

    public DbSet<Visitor> Visitors => Set<Visitor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}