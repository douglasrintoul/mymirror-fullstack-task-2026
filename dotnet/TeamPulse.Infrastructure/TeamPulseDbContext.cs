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

        // TODO: Populate some PulseCategory rows here for dummy data
    }

}
