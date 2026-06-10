using Microsoft.EntityFrameworkCore;

namespace azurra.Server.Repository;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Models.File> Files => Set<Domain.Models.File>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Models.File>(entity =>
        {
            entity.ToTable("Files");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.ReferenceFile).HasMaxLength(500);
            entity.Property(e => e.Desc).HasMaxLength(2000);
            entity.Property(e => e.Status).HasMaxLength(50);
        });
    }
}
