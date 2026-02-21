using Microsoft.EntityFrameworkCore;
using TeamPulse.Domain;

namespace TeamPulse.Infrastructure;

public class TeamPulseDbContext : DbContext
{
    public DbSet<PulseCategory> PulseCategories => Set<PulseCategory>();
    public DbSet<PulseEntry> PulseEntries => Set<PulseEntry>();

    public TeamPulseDbContext(DbContextOptions<TeamPulseDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the relationship between PulseEntries and PulseCategories
        modelBuilder.Entity<PulseEntry>()
            .HasOne<PulseCategory>()
            .WithMany()
            .HasForeignKey(e => e.CategoryId);

        // Define conversion from int scores to PulseScore objects
        modelBuilder.Entity<PulseEntry>()
            .Property(e => e.Score)
            .HasConversion(
                s => s.Value,
                v => new PulseScore(v)
            );

        modelBuilder.Entity<PulseCategory>().HasData(
            new PulseCategory(Guid.Parse("a1b2c3d4-0001-0000-0000-000000000000"), "Workload"),
            new PulseCategory(Guid.Parse("a1b2c3d4-0002-0000-0000-000000000000"), "Collaboration"),
            new PulseCategory(Guid.Parse("a1b2c3d4-0003-0000-0000-000000000000"), "Wellbeing"),
            new PulseCategory(Guid.Parse("a1b2c3d4-0004-0000-0000-000000000000"), "Team Dynamics"),
            new PulseCategory(Guid.Parse("a1b2c3d4-0005-0000-0000-000000000000"), "Environment"),
            new PulseCategory(Guid.Parse("a1b2c3d4-0006-0000-0000-000000000000"), "Mascot Performance")
        );

    }

}
